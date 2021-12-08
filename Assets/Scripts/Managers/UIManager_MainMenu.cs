using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

    public Text txtExample;
    public Vector3 small = new Vector3(0.6f, 0.6f, 1f);
    public Vector3 medium = new Vector3(0.7f, 0.7f, 1f);
    public Vector3 large = new Vector3(0.8f, 0.8f, 1f);
    public Vector3 CurrentFontSize { get; set; }

    public Slider musicVolume;
    public Slider sfxVolume;
    int[] musicSounds = new int[] { 0 };
    int[] sfxSounds = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        settingsMainPanel.SetActive(false);

        musicVolume.value = 0.05f;
        sfxVolume.value = 0.05f;
        CurrentFontSize = medium;
        txtExample.gameObject.transform.localScale = CurrentFontSize;
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

    public void AdjustMusicVolume()
    {
        //raise or lower volume based on the slider that was adjusted
        //Debug.Log("music volume changed");
        AudioManager.Instance.AdjustVolume(musicVolume.value, musicSounds);
    }

    public void AdjustSFXVolume()
    {
        //raise or lower volume based on the slider that was adjusted
        //Debug.Log("sfx volume changed");
        AudioManager.Instance.AdjustVolume(sfxVolume.value, sfxSounds);
    }

    //pass in size to change font size to
    public void SmallFontSize()
    {
        //change all font sizes to small  
        //Debug.Log("small font");
        CurrentFontSize = small;
        txtExample.gameObject.transform.localScale = CurrentFontSize;
    }

    public void MediumFontSize()
    {
        //change all font sizes to medium  
        //Debug.Log("medium font");
        CurrentFontSize = medium;
        txtExample.gameObject.transform.localScale = CurrentFontSize;
    }

    public void LargeFontSize()
    {
        //change all font sizes to large 
        //Debug.Log("large font");
        CurrentFontSize = large;
        txtExample.gameObject.transform.localScale = CurrentFontSize;
    }
}
