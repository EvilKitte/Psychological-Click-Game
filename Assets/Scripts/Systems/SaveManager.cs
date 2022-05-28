using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private PlotData[] plot;
    [SerializeField] private string[] sceneNames;
    private static string scoresResultKey = "Score";

    public static bool loadSceneFromEnd = false;
    private static PlotData currentPlotPiece;
    private static int numberCurrentPlotPiece = 0;
    private static int numberCurrentScene = 0;

    private static PlotData[] Plot;
    private static string[] SceneNames;

    private void Start()
    {
        Plot = plot;
        currentPlotPiece = Plot[0];
        SceneNames = sceneNames;
        DontDestroyOnLoad(this.gameObject);
    }
    public static void SetDefault()
    {
        PlayerPrefs.SetInt(PersonalityTrait.Extra_Introversion.ToString(), 0);
        PlayerPrefs.SetInt(PersonalityTrait.Neuroticism.ToString(), 0);
        PlayerPrefs.SetInt(PersonalityTrait.Psychoticism.ToString(), 0);
        PlayerPrefs.SetInt(PersonalityTrait.LieScale.ToString(), 0);
        PlayerPrefs.SetInt(scoresResultKey, 0);
        PlayerPrefs.Save();
    }

    public static void AddTraitPoint(PersonalityTrait trait)
    {
        int score = PlayerPrefs.GetInt(trait.ToString()) + 1;
        PlayerPrefs.SetInt(trait.ToString(), score);
        PlayerPrefs.Save();
    }

    public static int GetTraitPoints(PersonalityTrait trait)
    {
        return PlayerPrefs.GetInt(trait.ToString());
    }

    public static void SaveScorePoints(int score)
    {
        int result = PlayerPrefs.GetInt(scoresResultKey) + score;
        PlayerPrefs.SetInt(scoresResultKey, result);
        PlayerPrefs.Save();
    }

    public static int GetScore()
    {
        return PlayerPrefs.GetInt(scoresResultKey);
    }

    public static void SetNextPlotPiece()
    {
        numberCurrentPlotPiece++;
        if(numberCurrentPlotPiece < Plot.Length)
            currentPlotPiece = Plot[numberCurrentPlotPiece];
    }

    public static PlotData GetCurrentPlotPiece()
    {
        return currentPlotPiece;
    }

    public static string GetNextSceneName()
    {
        string nextSceneName = SceneNames[numberCurrentScene];
        numberCurrentScene++;
        return nextSceneName;
    }
}
