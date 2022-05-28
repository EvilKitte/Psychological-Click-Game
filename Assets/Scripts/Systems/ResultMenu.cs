using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultMenu : MonoBehaviour
{
    [SerializeField] private Text traitsText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text temperamentText;

    void OnEnable()
    {
        ShowTraitsPoints();
        ShowScore();
        ShowTemperament();
    }

    private void ShowTraitsPoints()
    {
        string textForRecords = "";
        textForRecords += "Экстра-Интроверсия: " + SaveManager.GetTraitPoints(PersonalityTrait.Extra_Introversion) + "\n";
        textForRecords += "Нейротизм: " + SaveManager.GetTraitPoints(PersonalityTrait.Neuroticism) + "\n";
        textForRecords += "Психотизм: " + SaveManager.GetTraitPoints(PersonalityTrait.Psychoticism) + "\n";
        textForRecords += "Шкала Лжи: " + SaveManager.GetTraitPoints(PersonalityTrait.LieScale) + "\n";
        traitsText.text = textForRecords;
    }

    private void ShowScore()
    {
        scoreText.text = "Сумма очков: " + SaveManager.GetScore();
    }

    private void ShowTemperament()
    {
        int extraIntroversion = SaveManager.GetTraitPoints(PersonalityTrait.Extra_Introversion);
        int neuroticism = SaveManager.GetTraitPoints(PersonalityTrait.Neuroticism);

        if (extraIntroversion > 12 && neuroticism > 12)
            temperamentText.text = "Ваш тип темперамента: холерик";
        if (extraIntroversion <= 12 && neuroticism > 12)
            temperamentText.text = "Ваш тип темперамента: меланхолик";
        if (extraIntroversion > 12 && neuroticism <= 12)
            temperamentText.text = "Ваш тип темперамента: сангвиник";
        if (extraIntroversion <= 12 && neuroticism <= 12)
            temperamentText.text = "Ваш тип темперамента: флегматик";
    }

    public void ReturnToMenu()
    {
        SaveManager.loadSceneFromEnd = true;
        SceneManager.LoadScene("StartScene");
    }
}
