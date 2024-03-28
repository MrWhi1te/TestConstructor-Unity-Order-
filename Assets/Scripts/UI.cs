using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private QuestionManager _QuestionManager;
    [SerializeField] private LoadScriptable _LoadScriptable;

    [SerializeField] private GameObject startPan;
    [SerializeField] private GameObject questionPan;
    [SerializeField] private GameObject questionCheckPan;
    [SerializeField] private GameObject commentBttn;
    [SerializeField] private GameObject commentPan;
    [SerializeField] private GameObject endPan;

    [SerializeField] private Text commentText;
    [SerializeField] private Text endText;
    [SerializeField] private Text checkText;

    private int rightAnswerCount;

    public void StartGame()
    {
        _QuestionManager.numberQuestion = 0;
        rightAnswerCount = 0;
        _LoadScriptable.CreateQuestionList();
        questionPan.SetActive(true);
        endPan.SetActive(false);
        startPan.SetActive(false);
    }

    public void ExitMenu()
    {
        startPan.SetActive(true);
        questionPan.SetActive(false);
        endPan.SetActive(false);
    }

    public void ClosedGame()
    {
        Application.Quit();
    }

    public void NextQuestion()
    {
        _QuestionManager.numberQuestion++;
        if (_QuestionManager.numberQuestion < _QuestionManager.randomQuestionList.Count)
        {
            _QuestionManager.NewQuestion();
        }
        else
        {
            questionPan.SetActive(false);
            endPan.SetActive(true);
            endText.text = "¬ы ответили правильно на " + rightAnswerCount + " вопросов из " + _QuestionManager.randomQuestionList.Count;
        }
        questionCheckPan.SetActive(false);
        commentPan.SetActive(false);
        commentBttn.SetActive(false);
    }

    public void CheckAnswer(string answer)
    {
        questionCheckPan.SetActive(true);

        if (_QuestionManager.randomQuestionList[_QuestionManager.numberQuestion].comment != "") commentBttn.SetActive(true);
        else commentBttn.SetActive(false);

        if(answer == "Correct")
        {
            rightAnswerCount++;
            checkText.text = "¬ы ответили правильно!";
            checkText.color = Color.green;
        }
        else
        {
            checkText.text = "¬ы неправильно выбрали один или несколько вариантов";
            checkText.color = Color.yellow;
        }
    }

    public void OpenClosedCommentPan()
    {
        if(!commentPan.activeInHierarchy)
        {
            commentPan.SetActive(true);
            commentText.text = _QuestionManager.randomQuestionList[_QuestionManager.numberQuestion].comment;
        }
        else commentPan.SetActive(false);
    }
}
