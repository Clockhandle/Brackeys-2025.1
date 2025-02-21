using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueData dialogueData;

    public void TriggerDialogue()
    {
        if (dialogueData != null)
        {
            DialogueManager.Instance.StartDialogue(dialogueData);
        }
    }
}
