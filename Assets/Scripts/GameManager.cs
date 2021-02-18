using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

/// <summary> Manages the state of the whole application </summary>
public class GameManager : MonoBehaviour
{
    private int highScore = 0; // highscore here since it's independent from the current level and needs to be shown on different menus

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private GameObject playMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private LevelManager levelManager;

    [SerializeField] private Text lastScoreGame;
    [SerializeField] private Text lastScoreLose;
    [SerializeField] private Text highScoreMain;
    [SerializeField] private Text highScoreLose;

    [SerializeField] private SaveLoadSystem saveLoadSystem;

    private void Start()
    {
        // Load highscore to show it on MainMenu
        highScore = saveLoadSystem.LoadPlayerData();
        highScoreMain.text = "Highscore: " + highScore.ToString();
        Time.timeScale = 0f;
    }

    private void Update()
    {
        // Check for input to pause or quit the game
        // If its currently playing + ESC -> Pause
        // If its on Main menu + ESC -> Quit application
        if (Input.GetKeyDown(KeyCode.Escape) && playMenu.activeInHierarchy) Pause();
        else if (Input.GetKeyDown(KeyCode.Escape) && mainMenu.activeInHierarchy) Application.Quit();
    }

    public void Play()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
        playMenu.SetActive(true);
        levelManager.Reset();
        
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Lose()
    {
        Time.timeScale = 0f;
        playMenu.SetActive(false);
        // if new score its higher than highest score, save it as the highest score
        if (levelManager.Score > highScore)
        {
            highScore = levelManager.Score;
            saveLoadSystem.SavePlayerData(highScore);
        }

        loseMenu.SetActive(true);
        lastScoreLose.text = "Lastscore: " + levelManager.Score.ToString();
        highScoreLose.text = "Highscore: " + highScore.ToString();

    }

    public LevelManager GetLevelManager()
    {
        return levelManager;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        playMenu.SetActive(true);
        loseMenu.SetActive(false);
        levelManager.Reset();
    }

    public void ReturnMainMenu()
    {
        Time.timeScale = 0f;
        loseMenu.SetActive(false);
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
        playMenu.SetActive(false);
        highScoreMain.text = "Highscore: " + highScore.ToString();
        levelManager.Reset();
    }
}