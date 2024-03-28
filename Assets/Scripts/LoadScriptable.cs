using System.Collections.Generic;
using UnityEngine;

public class LoadScriptable : MonoBehaviour
{
    [SerializeField] private QuestionManager _QuestionManager;

    void Start()
    {
        _QuestionManager.loadQuestionList = new List<QuestionData>(Resources.LoadAll<QuestionData>("Questions"));
    }

    public void CreateQuestionList()
    {
        List<QuestionData> temporList = new List<QuestionData>(_QuestionManager.loadQuestionList);

        _QuestionManager.randomQuestionList.Clear();

        if (temporList.Count > 60) RandomList(temporList, 60);
        else RandomList(temporList, temporList.Count);
    }

    void RandomList(List<QuestionData> temporList, int value)
    {
        Debug.Log("Сколько передано временный: " + temporList.Count);
        System.Random random = new System.Random();
        
        for (int i = 0; i < value; i++)
        {
            int randomIndex = random.Next(temporList.Count);
            _QuestionManager.randomQuestionList.Add(temporList[randomIndex]);
            temporList.RemoveAt(randomIndex);
            Debug.Log("Количество в листе: " + _QuestionManager.loadQuestionList.Count);
            Debug.Log("Количество временный: " + temporList.Count);
        }
        _QuestionManager.NewQuestion();
    }
}
