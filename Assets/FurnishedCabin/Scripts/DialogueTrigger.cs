using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class DialogueLine
{ 
    [TextArea(3, 20)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue specialDialoge;
    public UnityEvent unityDialogueTriggerEvent;
    public void TriggerDialogue()
    {
        if (DialogueManager.Instance.isDialogueActive)
        {
            DialogueManager.Instance.DisplayNextDialogueLine();
        }
        else
        {
            if (PlayerState.HasKey)
            {
                DialogueManager.Instance.StartDialogue(specialDialoge);
                TriggerSpecialEventWithDelay(2.0f); // 2 seconds delay
            }
            else
            {
                DialogueManager.Instance.StartDialogue(dialogue);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // Detect player leaving the zone
        {
            DialogueManager.Instance.EndDialogue(); // End dialogue
            StartDoorEvent.count = 0; // Holy shit this is unsightly
        }
    }

    public void TriggerSpecialEventWithDelay(float delay)
    {
        Invoke(nameof(InvokeSpecialDialogueEvent), delay);
    }

    private void InvokeSpecialDialogueEvent()
    {
        unityDialogueTriggerEvent?.Invoke();
    }


}