using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private UI _UI;

    [HideInInspector] public List<QuestionData> loadQuestionList = new();
    [HideInInspector] public List<QuestionData> randomQuestionList;
    [HideInInspector] public int numberQuestion;

    private QuestionData question;
    [SerializeField] private Text questionText;
    [SerializeField] private Text numberQuestionText;
    [SerializeField] private Image questionImage;
    [SerializeField] private Toggle[] answerToggle;

    private string[] correctAnswers;
    private string[] incorrectAnswers;
    private List<string> allAnswers;

    public void NewQuestion()
    {
        for (int i = 0; i < answerToggle.Length; i++)
        {
            answerToggle[i].isOn = false;
            answerToggle[i].gameObject.SetActive(false);
        }
        Debug.Log(numberQuestion);
        Debug.Log(randomQuestionList.Count);
        question = randomQuestionList[numberQuestion];
        questionText.text = question.question;
        numberQuestionText.text = "Вопрос " + numberQuestion + " из " + randomQuestionList.Count;

        correctAnswers = question.rightAnswer;
        incorrectAnswers = question.wrongAnswer;

        allAnswers = new List<string>();
        allAnswers.AddRange(correctAnswers);
        allAnswers.AddRange(incorrectAnswers);

        Shuffle(allAnswers);

        for (int i = 0; i < allAnswers.Count; i++)
        {
            answerToggle[i].GetComponentInChildren<Text>().text = allAnswers[i];
            answerToggle[i].gameObject.SetActive(true);
        }

        if(randomQuestionList[numberQuestion].picture != null)
        {
            questionImage.sprite = randomQuestionList[numberQuestion].picture;
            questionImage.gameObject.SetActive(true);
        } 
        else questionImage.gameObject.SetActive(false);
    }

    private void Shuffle<T>(List<T> list)
    {
        int i = list.Count;
        while (i > 1)
        {
            i--;
            int r = Random.Range(0, i + 1);
            T value = list[r];
            list[r] = list[i];
            list[i] = value;
        }
    }

    public void CheckAnswer()
    {
        bool allCorrect = true;

        for (int i = 0; i < allAnswers.Count; i++)
        {
            bool isCorrect = false;

            for (int j = 0; j < correctAnswers.Length; j++)
            {
                if (allAnswers[i] == correctAnswers[j])
                {
                    isCorrect = true;
                    break;
                }
            }

            if (answerToggle[i].isOn != isCorrect)
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            _UI.CheckAnswer("Correct");
        }
        else
        {
            _UI.CheckAnswer("UnCorrect");
        }
    }
}
