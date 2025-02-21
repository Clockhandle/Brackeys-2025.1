using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class QuestionSetUP1 : MonoBehaviour
{
    //Button to active Screen2
    [SerializeField] Button button2;
    //end
    [SerializeField] public List<QuestionData> questions;

    private QuestionData currentQuestion;

    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private bool isYes;
    [SerializeField] private int count;
    [SerializeField] private AnswerButton1[] answerButtons;

    [SerializeField] private int yesAnswerChoice;

    public static QuestionSetUP1 instance;

    public bool isScreen1, isScreen2, isScreen3;

    private void Awake()
    {
          
      if(instance == null)
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
         questions.AddRange(Resources.LoadAll<QuestionData>("Questions1"));
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

        if(questions.Count == 0)
        {
            button2.interactable = true;
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
            if(randomIndex ==0 && !isYesAnswerChosen)
            {
                yesAnswerChoice = i;
                isYesAnswerChosen= true;    
            }
            newList.Add(originList[randomIndex]);
            originList.RemoveAt(randomIndex);
        }

        return newList;
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class QuestionSetUP : MonoBehaviour
//{
//    [SerializeField] public List<QuestionData> questions;

//    private QuestionData currentQuestion;

//    [SerializeField] private TextMeshProUGUI questionText;
//    [SerializeField] private bool isYes;
//    [SerializeField] private int count;
//    [SerializeField] private AnswerButton[] answerButtons;

//    [SerializeField] private int yesAnswerChoice;

//    public static QuestionSetUP instance;

//    public bool isScreen1, isScreen2, isScreen3;

//    private void Awake()
//    {
//        isScreen1 = true;
//         GetQuestionAsset();
//        if (instance == null) { instance = this; }
//        // No need to call GetQuestionAsset() here
//    }

//    public void Start()
//    {
//        // Optionally, initialize with default screen
//        SetScreen(isScreen1, isScreen2);
//    }

//    private void Update()
//    {
//        // Update logic if needed
//    }

//    public void SetScreen(bool screen1, bool screen2)
//    {
//        isScreen1 = screen1;
//        isScreen2 = screen2;



//        SelectNewQuestion();
//        SetQuestionValues();
//        SetAnswerValues();
//    }

//    public void GetQuestionAsset()
//    {
//        if (questions == null)
//        {
//            questions = new List<QuestionData>();
//        }
//        else
//        {
//            questions.Clear(); // Clear the existing list
//        }

//        if (isScreen1)
//        {
//            questions.AddRange(Resources.LoadAll<QuestionData>("Questions1"));
//        }
//        else if (isScreen2)
//        {
//            questions.AddRange(Resources.LoadAll<QuestionData>("Questions2"));
//        }


//        Debug.Log("Questions Count: " + (questions.Count));
//    }

//    public void SelectNewQuestion()
//    {
//        if (questions.Count == 0)
//        {
//            Debug.LogWarning("No questions available.");
//            return;
//        }

//        int index = Random.Range(0, questions.Count);
//        currentQuestion = questions[index];
//        questions.RemoveAt(index);
//    }

//    public void SetQuestionValues()
//    {
//        if (currentQuestion != null)
//        {
//            questionText.text = currentQuestion.question;
//            isYes = currentQuestion.isYes;
//            count = currentQuestion.count;
//        }
//        else
//        {
//            Debug.LogWarning("Current question is null.");
//        }
//    }

//    public void SetAnswerValues()
//    {
//        if (answerButtons == null || answerButtons.Length == 0)
//        {
//            Debug.LogWarning("Answer buttons are not assigned or empty.");
//            return;
//        }

//        if (currentQuestion == null || currentQuestion.answer == null)
//        {
//            Debug.LogWarning("Current question or its answers are not set.");
//            return;
//        }

//        List<string> answers = RandommizeAnswers(new List<string>(currentQuestion.answer));

//        for (int i = 0; i < answerButtons.Length; i++)
//        {
//            if (i >= answers.Count)
//            {
//                Debug.LogWarning($"Answer button {i} is missing an answer.");
//                continue;
//            }

//            bool isYesTemp = (i == yesAnswerChoice);
//            answerButtons[i].IsYes(isYesTemp);
//            answerButtons[i].SetAnswerText(answers[i]);
//        }
//    }

//    private List<string> RandommizeAnswers(List<string> originList)
//    {
//        List<string> newList = new List<string>(originList);

//        // Shuffle the list
//        for (int i = 0; i < newList.Count; i++)
//        {
//            string temp = newList[i];
//            int randomIndex = Random.Range(i, newList.Count);
//            newList[i] = newList[randomIndex];
//            newList[randomIndex] = temp;
//        }

//        if (newList.Count > 0)
//        {
//            yesAnswerChoice = Random.Range(0, newList.Count);
//        }

//        return newList;
//    }
//}
