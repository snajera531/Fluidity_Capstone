using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager_InGame : MonoBehaviour
{
    #region Singleton
    private static UIManager_InGame _instance;

    public static UIManager_InGame Instance { get { return _instance; } }

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

    public enum eVolume
    {
        Music,
        Narration,
        SFX
    }

    public GameObject pausePanel;
    public GameObject settingsGamePanel;



    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pausePanel.SetActive(false);
        settingsGamePanel.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

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

    //settings functionality
    public void AdjustMusicVolume()
    {
        //raise or lower volume based on the slider that was adjusted
        Debug.Log("music volume changed");
    }
    
    public void AdjustNarrationVolume()
    {
        //raise or lower volume based on the slider that was adjusted
        Debug.Log("narration volume changed");
    }
    
    public void AdjustSFXVolume()
    {
        //raise or lower volume based on the slider that was adjusted
        Debug.Log("sfx volume changed");
    }

    //pass in size to change font size to
    public void SmallFontSize()
    {
        //change all font sizes to small  
        Debug.Log("small font");
    }
    
    public void MediumFontSize()
    {
        //change all font sizes to medium  
        Debug.Log("medium font");
    }

    public void LargeFontSize()
    {
        //change all font sizes to large 
        Debug.Log("large font");
    }
}
