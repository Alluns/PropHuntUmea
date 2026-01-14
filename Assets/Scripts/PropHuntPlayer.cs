using System;
using TMPro;
using Unity.Netcode;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PropHuntPlayer : NetworkBehaviour
{
    [SerializeField] public TextMeshPro teamLabel;

    [SerializeField] private GameObject hiderPrefab;
    [SerializeField] private GameObject seekerPrefab;
    [SerializeField] private GameObject spectatorPrefab;

    private GameObject currentForm;
    private PlayerController currentController;
    
    public enum Team
    {
        Seeker,
        Hider,
        Spectator,
    }

    public NetworkVariable<Team> team = new NetworkVariable<Team>(Team.Hider, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
    // public Team team;

    private void Start()
    {
        teamLabel.text = Enum.GetName(typeof(Team), team.Value);
        OnTeamChange(team.Value, team.Value);
        if (!IsOwner)
            return;


        (NetworkManager.Singleton as GameManager).RequestTeamChange_ServerRpc(this, Team.Spectator);

    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        team.OnValueChanged += OnTeamChange;
    }

    public override void OnNetworkDespawn()
    {
        base.OnNetworkDespawn();
        
        team.OnValueChanged -= OnTeamChange;
        
    }

    private void Update()
    {
        if (!IsOwner)
            return;
        
        if (currentController)
            currentController.PlayerUpdate();

        if (Keyboard.current.f1Key.isPressed)
            if (team.Value != Team.Hider)
                (NetworkManager.Singleton as GameManager).RequestTeamChange_ServerRpc(this, Team.Hider);
        
        if (Keyboard.current.f2Key.isPressed)
            if (team.Value != Team.Spectator)
                (NetworkManager.Singleton as GameManager).RequestTeamChange_ServerRpc(this, Team.Spectator);
        
        if (Keyboard.current.f3Key.isPressed)
            if (team.Value != Team.Seeker)
                (NetworkManager.Singleton as GameManager).RequestTeamChange_ServerRpc(this, Team.Seeker);
    }

    [ClientRpc]
    public void ChangeTeam_ClientRpc(Team newTeam)
    {
        if (!IsOwner)
            return;
        // print("received message to change teams");
        // return;
        
        team.Value = newTeam;
        teamLabel.text = Enum.GetName(typeof(Team), newTeam);
    }

    public void OnTeamChange(Team previousValue, Team newValue)
    {
        // team.Value = newValue;
        teamLabel.text = Enum.GetName(typeof(Team), team.Value);
        
        // if (previousValue == newValue)
        //     return;
        
        if (currentForm)
            Destroy(currentForm);
        
        if (currentController)
            Destroy(currentController);

        GameObject prefab = team.Value switch
        {
            Team.Seeker => seekerPrefab,
            Team.Hider => hiderPrefab,
            Team.Spectator => spectatorPrefab,
            _ => throw new ArgumentOutOfRangeException()
        };

        currentController = team.Value switch
        {
            Team.Seeker => gameObject.AddComponent<SeekerController>(),
            Team.Hider => gameObject.AddComponent<HiderController>(),
            Team.Spectator => gameObject.AddComponent<SpectatorController>(),
            _ => throw new ArgumentOutOfRangeException()
        };

        currentForm = Instantiate(prefab, transform);
    }
}
