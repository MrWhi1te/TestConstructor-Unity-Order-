using UnityEngine;

[CreateAssetMenu(fileName = "Вопрос", menuName = "Вопросы/вопрос")]
public class QuestionData : ScriptableObject
{
    [Tooltip("Вопрос")] [TextArea(2, 3)] public string question;
    [Tooltip("Картинка")] public Sprite picture;
    [Tooltip("Правильный ответ")] [TextArea(2, 2)] public string[] rightAnswer;
    [Tooltip("Неправильный ответ")] [TextArea(2, 2)] public string[] wrongAnswer;
    [Tooltip("")] [TextArea(2, 3)] public string comment;
}
