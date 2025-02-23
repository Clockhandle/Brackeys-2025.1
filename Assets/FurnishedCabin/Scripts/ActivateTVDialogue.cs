using UnityEngine;
using TMPro;
public class ActivateTVDialogue : MonoBehaviour
{
    public GameObject TVDialogueBox;
    public TextMeshProUGUI TVDialogueArea;
    public void ChangeDialogueBoxAndArea()
    {
        PlayerState.IsLooking = false;
        PlayerState.IsMoving = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        DialogueManager.Instance.defaultDialogueBox = TVDialogueBox;
        DialogueManager.Instance.dialogueArea = TVDialogueArea;
    }
}
