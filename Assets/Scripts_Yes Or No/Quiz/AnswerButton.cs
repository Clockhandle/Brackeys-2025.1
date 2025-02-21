using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerButton1 : MonoBehaviour
{
    private bool isYes;
    [SerializeField] private TextMeshProUGUI answerText;
    // [SerializeField] private QuestionSetUP1 questionSetup;

  
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

            if (QuestionSetUP1.instance.questions.Count > 0)
            {
                QuestionSetUP1.instance.Start();
            }


        }
        else
        {
            Debug.Log("Is No");

            // Generate a new question
            if (QuestionSetUP1.instance.questions.Count > 0)
            {
                QuestionSetUP1.instance.Start();
            }

        }
    }
}
