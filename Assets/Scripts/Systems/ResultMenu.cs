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
        textForRecords += "������-�����������: " + SaveManager.GetTraitPoints(PersonalityTrait.Extra_Introversion) + "\n";
        textForRecords += "���������: " + SaveManager.GetTraitPoints(PersonalityTrait.Neuroticism) + "\n";
        textForRecords += "���������: " + SaveManager.GetTraitPoints(PersonalityTrait.Psychoticism) + "\n";
        textForRecords += "����� ���: " + SaveManager.GetTraitPoints(PersonalityTrait.LieScale) + "\n";
        traitsText.text = textForRecords;
    }

    private void ShowScore()
    {
        scoreText.text = "����� �����: " + SaveManager.GetScore();
    }

    private void ShowTemperament()
    {
        int extraIntroversion = SaveManager.GetTraitPoints(PersonalityTrait.Extra_Introversion);
        int neuroticism = SaveManager.GetTraitPoints(PersonalityTrait.Neuroticism);

        if (extraIntroversion > 12 && neuroticism > 12)
            temperamentText.text = "��� ��� ������������: �������";
        if (extraIntroversion <= 12 && neuroticism > 12)
            temperamentText.text = "��� ��� ������������: ����������";
        if (extraIntroversion > 12 && neuroticism <= 12)
            temperamentText.text = "��� ��� ������������: ���������";
        if (extraIntroversion <= 12 && neuroticism <= 12)
            temperamentText.text = "��� ��� ������������: ���������";
    }

    public void ReturnToMenu()
    {
        SaveManager.loadSceneFromEnd = true;
        SceneManager.LoadScene("StartScene");
    }
}
