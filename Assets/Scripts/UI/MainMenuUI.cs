using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button joinButton;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private TMP_InputField ipField;

    [SerializeField] private Canvas gameUI;

    private void Start()
    {
        joinButton.onClick.AddListener(JoinGame);
        hostButton.onClick.AddListener(HostGame);
        exitButton.onClick.AddListener(ExitGame);
        
        ipField.onValueChanged.AddListener(UpdateIP);
        ipField.text = NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Address;
    }

    private void JoinGame()
    {
        if (NetworkManager.Singleton.StartClient())
        {
            Debug.Log("Client started");

            gameUI.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Client failed to start");
        }
    }

    private void HostGame()
    {
        if (NetworkManager.Singleton.StartHost())
        {
            Debug.Log("Server started");

            gameUI.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Client failed to start");
        }
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void UpdateIP(string ip)
    {
        NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Address = ip;
    }
}