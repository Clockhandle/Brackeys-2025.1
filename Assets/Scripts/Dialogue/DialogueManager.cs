using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private GameObject dialoguePanel; // UI Panel
    [SerializeField] private TMP_Text dialogueText; // TextMeshPro text
    [SerializeField] private float textSpeed = 0.05f;

    private string[] currentDialogue;
    private int currentLine;
    private bool isDialogueActive = false; // Track if dialogue is active

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.I))
        {
            NextDialogue();
        }
    }

    public void StartDialogue(DialogueData dialogueData)
    {
        if (isDialogueActive) return; // Prevent restarting during dialogue

        currentDialogue = dialogueData.dialogueLines;
        currentLine = 0;
        dialoguePanel.SetActive(true);
        isDialogueActive = true;
        StartCoroutine(TypeDialogue());
    }

    private IEnumerator TypeDialogue()
    {
        dialogueText.text = "";
        foreach (char letter in currentDialogue[currentLine])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextDialogue()
    {
        if (currentLine < currentDialogue.Length - 1)
        {
            currentLine++;
            StartCoroutine(TypeDialogue());
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
    }
}
