using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkManager
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get => instance;
        set => instance = value;
    }
    
    [SerializeField] private GameObject menu;

    private struct PlayerInfo
    {
        public float JoinTime;
        public PropHuntPlayer.Team Team;

        public PlayerInfo(float joinTime, PropHuntPlayer.Team team)
        {
            JoinTime = joinTime;
            Team = team;
        }
    }

    private void Start()
    {
        Instance = this;
    }

    private void OnDisable()
    {
    }

    public void RegisterPlayer()
    {
    }
    
    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
        InitScene();
    }

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        InitScene();
    }

    private void InitScene()
    {
        Camera.main.clearFlags = CameraClearFlags.Skybox;
        menu.SetActive(false);
    }

    [Rpc(SendTo.Server)]
    public void RequestTeamChange_ServerRpc(PropHuntPlayer player, PropHuntPlayer.Team team)
    {
        player.team.Value = team;
    }
}
