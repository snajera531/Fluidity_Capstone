using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

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

    public GameObject pauseMenuPanel;
    public GameObject[] colorOptions;
    public GameObject[] greyOptions;
    public GameObject[] colorPlatforms;
    public Player player;

    void Start()
    {
        pauseMenuPanel.SetActive(false);
    }

    private void Update()
    {
        CheckColorStatus();
    }

    //colors appearing
    //player finds red village and can select red as a color
    //same conditions for other colors
    public void CheckColorStatus()
    {
        if (player.hasRed)
        {
            colorOptions[0].SetActive(true);
        } 
        
        if(player.currentColor == Player.eColor.RED)
        {
            greyOptions[0].SetActive(false);
            greyOptions[1].SetActive(true);
            greyOptions[2].SetActive(true);

            colorPlatforms[0].SetActive(true);
            colorPlatforms[1].SetActive(false);
            colorPlatforms[2].SetActive(false);
        }

        if (player.hasGreen)
        {
            colorOptions[1].SetActive(true);
        }
        
        if (player.currentColor == Player.eColor.GREEN)
        {
            greyOptions[0].SetActive(true);
            greyOptions[1].SetActive(false);
            greyOptions[2].SetActive(true);

            colorPlatforms[0].SetActive(false);
            colorPlatforms[1].SetActive(true);
            colorPlatforms[2].SetActive(false);
        }

        if (player.hasBlue)
        {
            colorOptions[2].SetActive(true);
        }
        
        if (player.currentColor == Player.eColor.BLUE)
        {
            greyOptions[0].SetActive(true);
            greyOptions[1].SetActive(true);
            greyOptions[2].SetActive(false);

            colorPlatforms[0].SetActive(false);
            colorPlatforms[1].SetActive(false);
            colorPlatforms[2].SetActive(true);
        }
    }

    //pause menu methods
    public void PauseMenu()
    {
        player.paused = true;
        Cursor.visible = true;
        pauseMenuPanel.SetActive(true);
    }

    public void ExitPause()
    {
        player.paused = false;
        Cursor.visible = false;
        pauseMenuPanel.SetActive(false);
    }

    public void ExitGameToMainMenu()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
}
