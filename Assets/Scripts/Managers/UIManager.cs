using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager _instance;

    public static UIManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    //main menu panels
    public GameObject creditsPanel;
    public GameObject mainMenuPanel;
    public GameObject settingsMainPanel;
    //game menu panels
    public GameObject pausePanel;
    public GameObject settingsGamePanel;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        settingsMainPanel.SetActive(false);
    }

    //main menu ui functions
    public void MainMenu()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        settingsMainPanel.SetActive(false);
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        settingsMainPanel.SetActive(false);
    }
    
    public void SettingsMain()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        settingsMainPanel.SetActive(true);
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    //game ui functions
    public void Pause()
    {
        Cursor.visible = true;
        pausePanel.SetActive(true);
        settingsGamePanel.SetActive(false);
    }

    public void ExitPause()
    {
        Cursor.visible = false;
        pausePanel.SetActive(false);
        settingsGamePanel.SetActive(false);
    }

    public void SettingsGame()
    {
        pausePanel.SetActive(false);
        settingsGamePanel.SetActive(true);
    }
}
