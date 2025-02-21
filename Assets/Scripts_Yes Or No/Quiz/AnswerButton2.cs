using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerButton2 : MonoBehaviour
{
    private bool isYes;
    [SerializeField] private TextMeshProUGUI answerText;



    public void SetAnswerText(string newText)
    {
        answerText.text = newText;
    }

    public void IsYes(bool newbool)
    {
        isYes = newbool;
    }

    public void OnClick()
    {
        if (isYes)
        {
            Debug.Log("Is Yes");

            // Generate a new question
            if (QuestionSetUp2.instance.questions.Count > 0)
            {
                QuestionSetUp2.instance.Start();
            }

        }
        else
        {
            Debug.Log("Is No");

            // Generate a new question
            if (QuestionSetUp2.instance.questions.Count > 0)
            {
                QuestionSetUp2.instance.Start();
            }

        }
    }
}
