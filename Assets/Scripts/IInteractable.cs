using UnityEngine;

public interface IInteractable
{
    void Interact()
    {
        Debug.Log("Object does not have Interact override!");
    }
}
