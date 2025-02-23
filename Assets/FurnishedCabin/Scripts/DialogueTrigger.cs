using System.Collections;
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
    public UnityEvent TVDialogueTriggerEvent;
    public List<GameObject> buttonsToActivate; // Assign buttons in Unity Inspector

    public float activationDelay = 2f; // Time between button activations
    private int dialogueCount = 0;
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

    public void TVDialogue()
    {
        if (DialogueManager.Instance.isDialogueActive)
        {
            DialogueManager.Instance.DisplayNextDialogueLine();
            dialogueCount++;

            // After third dialogue interaction, start the button activation sequence
            if (dialogueCount >= 2)
            {
                StartCoroutine(ActivateButtonsGradually());
            }
        }
        else
        {
            TVDialogueTriggerEvent?.Invoke();
            DialogueManager.Instance.StartDialogue(dialogue);
        }
    }

    private IEnumerator ActivateButtonsGradually()
    {
        foreach (GameObject button in buttonsToActivate)
        {
            button.SetActive(true);
            yield return new WaitForSeconds(activationDelay); // Delay before activating the next button
        }
    }
}
