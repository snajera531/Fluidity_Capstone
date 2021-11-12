using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager_MainMenu : MonoBehaviour
{
    #region Singleton
    private static UIManager_MainMenu _instance;

    public static UIManager_MainMenu Instance { get { return _instance; } }

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

    public Animator transition;
    public int transitionTime = 1;
    //main menu panels
    public GameObject creditsPanel;
    public GameObject mainMenuPanel;
    public GameObject settingsMainPanel;

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
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
