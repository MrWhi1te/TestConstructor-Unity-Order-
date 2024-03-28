using UnityEngine;

[CreateAssetMenu(fileName = "������", menuName = "�������/������")]
public class QuestionData : ScriptableObject
{
    [Tooltip("������")] [TextArea(2, 3)] public string question;
    [Tooltip("��������")] public Sprite picture;
    [Tooltip("���������� �����")] [TextArea(2, 2)] public string[] rightAnswer;
    [Tooltip("������������ �����")] [TextArea(2, 2)] public string[] wrongAnswer;
    [Tooltip("")] [TextArea(2, 3)] public string comment;
}
