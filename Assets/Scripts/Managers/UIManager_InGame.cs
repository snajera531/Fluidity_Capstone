using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

    public Text txtExample;
    public Vector3 smallFont = new Vector3(0.6f, 0.6f, 1f);
    public Vector3 mediumFont = new Vector3(0.7f, 0.7f, 1f);
    public Vector3 largeFont = new Vector3(0.8f, 0.8f, 1f);
    public Vector3 CurrentFontSize { get; set; }

    public Slider musicVolume;
    public Slider narrationVolume;
    public Slider sfxVolume;
    int[] musicSounds = new int[] { 0 };
    int[] narrationSounds = new int[] {  };
    int[] sfxSounds = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pausePanel.SetActive(false);
        settingsGamePanel.SetActive(false);

        musicVolume.value = 0.05f;
        narrationVolume.value = 0.05f;
        sfxVolume.value = 0.05f;
        CurrentFontSize = mediumFont;
        txtExample.gameObject.transform.localScale = CurrentFontSize;
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

    public void SettingsGame()
    {
        pausePanel.SetActive(false);
        settingsGamePanel.SetActive(true);
    }

    //settings functionality
    public void AdjustMusicVolume()
    {
        //raise or lower volume based on the slider that was adjusted
        //Debug.Log("music volume changed");
        AudioManager.Instance.AdjustVolume(musicVolume.value, musicSounds);
    }
    
    public void AdjustNarrationVolume()
    {
        //raise or lower volume based on the slider that was adjusted
        //Debug.Log("narration volume changed");
        AudioManager.Instance.AdjustVolume(narrationVolume.value, narrationSounds);
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
        CurrentFontSize = smallFont;
        txtExample.gameObject.transform.localScale = CurrentFontSize;
    }

    public void MediumFontSize()
    {
        //change all font sizes to medium  
        //Debug.Log("medium font");
        CurrentFontSize = mediumFont;
        txtExample.gameObject.transform.localScale = CurrentFontSize;
    }

    public void LargeFontSize()
    {
        //change all font sizes to large 
        //Debug.Log("large font");
        CurrentFontSize = largeFont;
        txtExample.gameObject.transform.localScale = CurrentFontSize;
    }
}
