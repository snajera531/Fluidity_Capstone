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

    public Animator transition;
    public int transitionTime = 1;
    public GameObject pausePanel;
    public GameObject settingsGamePanel;
    DialogueManager dialogueManager;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pausePanel.SetActive(false);
        settingsGamePanel.SetActive(false);
    }

    public void MainMenu()
    {
        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadMainMenu()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        settingsGamePanel.SetActive(false);
    }

    public void ExitPause()
    {
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
        //Debug.Log("small font");
        dialogueManager.ChangeFontSize(dialogueManager.smallFont);
    }
    
    public void MediumFontSize()
    {
        //change all font sizes to medium  
        //Debug.Log("medium font");
        dialogueManager.ChangeFontSize(dialogueManager.mediumFont);
    }

    public void LargeFontSize()
    {
        //change all font sizes to large 
        //Debug.Log("large font");
        dialogueManager.ChangeFontSize(dialogueManager.largeFont);
    }
}
