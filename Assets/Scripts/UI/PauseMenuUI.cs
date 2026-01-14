using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private Button joinButton;
    [SerializeField] private Button spectateButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private Canvas mainMenu;

    private void Start()
    {
        joinButton.onClick.AddListener(JoinMatch);
        spectateButton.onClick.AddListener(JoinSpectators);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        mainMenuButton.onClick.AddListener(ExitGame);
    }

    private void JoinMatch()
    {
        throw new NotImplementedException();
    }

    private void JoinSpectators()
    {
        throw new NotImplementedException();
    }

    private void GoToMainMenu()
    {
        //Disconnect client or stop hosting
        mainMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    
    private void ExitGame()
    {
        Application.Quit();
    }
}
