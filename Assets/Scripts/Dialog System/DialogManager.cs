using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private PlotData plot;

    [SerializeField] private Text questionText;
    [SerializeField] private Text answerFirsText;
    [SerializeField] private Text answerSecondText;

    private QuestionData _currentQuestion;
    private int _currentQuestionNumber = 0;
    private int _nextQuestionNumber1;
    private int _nextQuestionNumber2;
    private bool _isPlotEnd = false;
    

    public bool IsPlotEnd { get => _isPlotEnd; }

    void Start()
    {
        plot = SaveManager.GetCurrentPlotPiece();
        ChangeQuestion();
    }

    public void ClickOnAnswer(int chosenAnswer)
    {
        if(chosenAnswer == 1)
            _currentQuestionNumber = _nextQuestionNumber1;
        else
            _currentQuestionNumber = _nextQuestionNumber2;

        AddPoint(chosenAnswer);
        _isPlotEnd = _currentQuestion.IsPlotEnd;

        if(!_isPlotEnd)
            ChangeQuestion();
    }

    private void ChangeQuestion()
    {
        _currentQuestion = plot.PlotList[_currentQuestionNumber];
        questionText.text = _currentQuestion.QuestionText;
        answerFirsText.text = _currentQuestion.AnswerFirst;

        if(_currentQuestion.AnswerSecond != "")
        {
            answerSecondText.text = _currentQuestion.AnswerSecond;
            answerSecondText.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            answerSecondText.transform.parent.gameObject.SetActive(false);
        }
        _nextQuestionNumber1 = _currentQuestion.NextQuestionAfterAnswer1;
        _nextQuestionNumber2 = _currentQuestion.NextQuestionAfterAnswer2;
    }

    private void AddPoint(int chosenAnswer)
    {
        if(_currentQuestion._personalityTrait != PersonalityTrait.Nothing && chosenAnswer == _currentQuestion.AnswerGivingPoint)
        {
            SaveManager.AddTraitPoint(_currentQuestion._personalityTrait);
        }
    }
}
