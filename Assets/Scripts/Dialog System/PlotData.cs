using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlotsData", fileName = "PlotData")]
public class PlotData : ScriptableObject
{
    [SerializeField] private List<QuestionData> _plotList;
    public List<QuestionData> PlotList { get => _plotList; set => _plotList = value; }
}

[System.Serializable]
public class QuestionData
{
    [SerializeField] private string _questionText;
    [SerializeField] private int _nextQuestionAfterAnswer1;
    [SerializeField] private int _nextQuestionAfterAnswer2;
    [SerializeField] public PersonalityTrait _personalityTrait;
    [SerializeField] private string _answerFirst;
    [SerializeField] private string _answerSecond;
    [SerializeField] private int _answerGivingPoint;
    [SerializeField] private bool _isPlotEnd;


    public string QuestionText { get => _questionText; set => _questionText = value; }
    public int NextQuestionAfterAnswer1 { get => _nextQuestionAfterAnswer1; set => _nextQuestionAfterAnswer1 = value; }
    public int NextQuestionAfterAnswer2 { get => _nextQuestionAfterAnswer2; set => _nextQuestionAfterAnswer2 = value; }
    public string AnswerFirst { get => _answerFirst; set => _answerFirst = value; }
    public string AnswerSecond { get => _answerSecond; set => _answerSecond = value; }
    public int AnswerGivingPoint { get => _answerGivingPoint; set => _answerGivingPoint = value; }
    public bool IsPlotEnd { get => _isPlotEnd; set => _isPlotEnd = value; }
}