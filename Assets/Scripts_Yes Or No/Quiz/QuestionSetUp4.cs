using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionSetUp4 : MonoBehaviour
{
    [SerializeField] private GameObject picture1;
    [SerializeField] private GameObject picture2;
    [SerializeField] private GameObject EndText;

    [SerializeField] public List<QuestionData> questions;

    private QuestionData currentQuestion;

    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private bool isYes;
    [SerializeField] private int count;
    [SerializeField] private AnswerButton4[] answerButtons;

    [SerializeField] private int yesAnswerChoice;

    public static QuestionSetUp4 instance;

    public bool isScreen1, isScreen2, isScreen3;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
           GetQuestionAsset();
    }

    public void Start()
    {
        SelectNewQuestion();
        SetQuestionValues();
        SetAnswerValues();

    }

    public void GetQuestionAsset()
    {
        questions.AddRange(Resources.LoadAll<QuestionData>("Questions4"));
    }

    public void SetBool1()
    {
        isScreen1 = true;
        isScreen2 = false;
    }
    public void SetBool2()
    {
        isScreen2 = true;
        isScreen1 = false;
    }


    int index = -1;
    public void SelectNewQuestion()
    {


        index = 0;


        currentQuestion = questions[index];
        questions.RemoveAt(index);

        if (questions.Count == 2)
        {
            picture1.SetActive(true);

        }
        else if (questions.Count == 1) 
        {
            picture1.SetActive(false);  
            picture2.SetActive(true);
        }
        else if (questions.Count == 0)
        {
              EndText.SetActive(true);
            picture2.SetActive(false);
            foreach (AnswerButton4 button in answerButtons)
            {
                button.gameObject.SetActive(false); 
            }
            return;

        }



    }
    public void SetQuestionValues()
    {
        if (currentQuestion != null)
        {
            questionText.text = currentQuestion.question;
            isYes = currentQuestion.isChange;
            count = currentQuestion.count;
        }
    }
    public void SetAnswerValues()
    {

        List<string> answers = RandommizeAnswers(new List<string>(currentQuestion.answer));

        for (int i = 0; i < answerButtons.Length; i++)
        {
            bool isYesTemp = false;
            if (i == yesAnswerChoice)
            {
                isYesTemp = true;
            }
            answerButtons[i].IsYes(isYesTemp);
            answerButtons[i].SetAnswerText(answers[i]);
        }
    }
    private List<string> RandommizeAnswers(List<string> originList)
    {
        bool isYesAnswerChosen = false;
        List<string> newList = new List<string>();

        for (int i = 0; i < answerButtons.Length; i++)
        {

            int randomIndex = Random.Range(0, originList.Count);
            if (randomIndex == 0 && !isYesAnswerChosen)
            {
                yesAnswerChoice = i;
                isYesAnswerChosen = true;
            }
            newList.Add(originList[randomIndex]);
            originList.RemoveAt(randomIndex);
        }

        return newList;
    }
}
