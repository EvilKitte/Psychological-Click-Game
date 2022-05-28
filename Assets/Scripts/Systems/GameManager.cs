using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public enum gameStates { Start, Menu, Playing, LoadLevel};
    public gameStates gameState = gameStates.Start;

    [SerializeField] private GameObject spawner;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioClip tapOnButtomAS;

    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject rulesCanvas;

    [SerializeField] private GameObject scoreCanvas;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject dialogCanvas;

    [SerializeField] private GameObject resultsCanvas;

    [SerializeField] private string nextSceneName;

    private int score = 0;
    private DialogManager dialogManager;

    void Start()
    {
        gameManager = gameObject.GetComponent<GameManager>();
        dialogManager = dialogCanvas.GetComponent<DialogManager>();

        if (SaveManager.loadSceneFromEnd)
            SetCanvasVisibility(false, true, false, false, false);
        else
            SetCanvasVisibility(true, false, false, false, false);
        backgroundMusic.volume = 0.1f;
    }

    void Update()
    {
        switch (gameState)
        {
            case gameStates.Playing:
                backgroundMusic.volume = 0.3f;
                if (dialogManager.IsPlotEnd)
                {
                    SaveManager.SetNextPlotPiece();
                    gameState = gameStates.LoadLevel;
                    spawner.GetComponent<MonsterSpawner>().canSpawn = false;
                    spawner.GetComponent<MonsterSpawner>().StopSpawn();
                    SaveManager.SaveScorePoints(score);
                }
                break;

            case gameStates.Menu:
                break;

            case gameStates.LoadLevel:
                SceneManager.LoadScene(SaveManager.GetNextSceneName());
                break;
        }
    }

    public void CountScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void StartGame()
    {
        backgroundMusic.PlayOneShot(tapOnButtomAS);
        SaveManager.SetDefault();
        score = 0;
        scoreText.text = score.ToString();

        SetCanvasVisibility(false, false, false, true, false);
        gameState = gameStates.Playing;
        spawner.GetComponent<MonsterSpawner>().canSpawn = true;
    }

    public void OpenRules()
    {
        backgroundMusic.PlayOneShot(tapOnButtomAS);

        SetCanvasVisibility(false, false, true, false, false);
        gameState = gameStates.Menu;
    }

    public void OpenMenu()
    {
        backgroundMusic.PlayOneShot(tapOnButtomAS);

        SetCanvasVisibility(false, true, false, false, false);
        gameState = gameStates.Menu;
    }

    public void OpenResults()
    {
        backgroundMusic.PlayOneShot(tapOnButtomAS);

        SetCanvasVisibility(false, false, false, false, true);
        gameState = gameStates.Menu;
    }

    public void QuitGame()
    {
        backgroundMusic.PlayOneShot(tapOnButtomAS);
        Application.Quit();
    }

    public void SetCanvasVisibility(bool startCanvasMode, bool menuCanvasMode, bool rulesCanvasMode,
                                    bool gameCanvasMode, bool resultsCanvasMode)
    {
        startCanvas.SetActive(startCanvasMode);
        menuCanvas.SetActive(menuCanvasMode);
        rulesCanvas.SetActive(rulesCanvasMode);
        scoreCanvas.SetActive(gameCanvasMode);
        dialogCanvas.SetActive(gameCanvasMode);
        resultsCanvas.SetActive(resultsCanvasMode);
    }
}
