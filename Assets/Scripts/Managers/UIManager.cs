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

    public GameObject creditsPanel;
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void MainMenu()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    
    public void Settings()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
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
}
