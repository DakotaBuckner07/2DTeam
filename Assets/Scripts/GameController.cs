using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject optionsScreen;
    public GameObject pauseScreen;
    public GameObject levelSelectScreen;
    public TextMeshProUGUI ScoreUI;

    public string screen = "Title";

    public AudioMixer audioMixer;

    public int highScore = 0;   

    bool isPaused = false;
    float timeScale;

    static GameController instance = null;

    public static GameController Instance { get { return instance; } }

    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        switch (screen)
        {
            case "Select":
                OnSelectScreen();
                break;
            case "Title":
                OnTitleScreen();
                break;
            case "Options":
                OnOptionsScreen();
                break;
            case "Pause":
                OnPauseScreen();
                break;
        }
    }

    void Start()
    {
        titleScreen.SetActive(true);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        PlayerPrefs.SetInt("HighScore", highScore);

    }

    public void OnLoadGameScene(string sceneString)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(LoadGameScene(sceneString));
    }

    IEnumerator LoadGameScene(string sceneString)
    {
        titleScreen.SetActive(false);
        SceneManager.LoadScene(sceneString);

        yield return null;
    }

    public void OnLoadMenuScene(string sceneString)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        StartCoroutine(LoadMenuScene(sceneString));
    }

    IEnumerator LoadMenuScene(string sceneString)
    {
        SceneManager.LoadScene(sceneString);
        titleScreen.SetActive(true);

        yield return null;
    }

    public void OnTitleScreen()
    {
        screen = "Title";
        titleScreen.SetActive(true);
        optionsScreen.SetActive(false);
        levelSelectScreen.SetActive(false);
    }

    public void OnSelectScreen()
    {
        screen = "Select";
        titleScreen.SetActive(false);
        optionsScreen.SetActive(false);
        levelSelectScreen.SetActive(true);

    }

    public void OnOptionsScreen()
    {
        screen = "Options";
        titleScreen.SetActive(false);
        optionsScreen.SetActive(true); 
        levelSelectScreen.SetActive(false);
    }

    public void OnPauseScreen()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = timeScale;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            timeScale = Time.timeScale;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void OnPause()
    {
        OnPauseScreen();    
    }

    public void OnMasterVolume(float level)
    {
        audioMixer.SetFloat("MasterVolume", level);
    }

    public void OnMusicVolume(float level)
    {
        audioMixer.SetFloat("MusicVolume", level);
    }

    public void OnSFXVolume(float level)
    {
        audioMixer.SetFloat("SFXVolume", level);
    }

}
