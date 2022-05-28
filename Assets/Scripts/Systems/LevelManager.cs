using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    public enum levelStates { Rules, Playing, LoadLevel, Menu};
    public levelStates levelState = levelStates.Rules;

    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioClip tapOnButtomAS;

    [SerializeField] private GameObject spawner;

    [SerializeField] private GameObject rulesCanvas;
    [SerializeField] private GameObject dialogCanvas;
    [SerializeField] private GameObject scoreCanvas;
    [SerializeField] private Text scoreText;

    [SerializeField] private GameObject resultCanvas;

    private DialogManager dialogManager;
    private int score = 0;

    void Start()
    {
        levelManager = gameObject.GetComponent<LevelManager>();
        dialogManager = dialogCanvas.GetComponent<DialogManager>();
        SetCanvasVisibility(false, true, false);
        backgroundMusic.volume = 0.1f;
    }

    void Update()
    {
        switch (levelState)
        {
            case levelStates.Playing:
                backgroundMusic.volume = 0.5f;
                if(dialogManager.IsPlotEnd)
                {
                    if (resultCanvas != null)
                        levelState = levelStates.Menu;
                    else
                        levelState = levelStates.LoadLevel;

                    SaveManager.SaveScorePoints(score);
                    SaveManager.SetNextPlotPiece();
                }
                break;

            case levelStates.Rules:
                break;

            case levelStates.LoadLevel:
                SceneManager.LoadScene(SaveManager.GetNextSceneName());
                break;

            case levelStates.Menu:
                OpenResults();
                break;
        }
    }

    public void StartGame()
    {
        backgroundMusic.PlayOneShot(tapOnButtomAS);

        SetCanvasVisibility(true, false, false);
        levelState = levelStates.Playing;
        spawner.GetComponent<MonsterSpawner>().canSpawn = true;
    }

    public void CountScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void OpenResults()
    {
        EndGame();
        SetCanvasVisibility(false, false, true);
        levelState = levelStates.Menu;
    }

    private void EndGame()
    {
        spawner.GetComponent<MonsterSpawner>().canSpawn = false;
        spawner.GetComponent<MonsterSpawner>().StopSpawn();
        for (int i = 0; i < spawner.transform.childCount; i++)
        {
            spawner.transform.GetChild(i).GetComponent<TimedDestructor>().Destroy(); ;
        }
        backgroundMusic.volume = 0.1f;
    }

    public void CkickSound()
    {
        backgroundMusic.PlayOneShot(tapOnButtomAS);
    }

    public void SetCanvasVisibility(bool gameCanvasMode, bool rulesCanvasMode, bool resultCanvasMode)
    {
        dialogCanvas.SetActive(gameCanvasMode);
        scoreCanvas.SetActive(gameCanvasMode);
        rulesCanvas.SetActive(rulesCanvasMode);
        if (resultCanvas != null)
            resultCanvas.SetActive(resultCanvasMode);
    }
}
