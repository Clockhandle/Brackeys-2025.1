using UnityEngine;

public class Sphere : MonoBehaviour, IInteractable
{
    void IInteractable.Interact()
    {
        Debug.Log("This is a sphere!");
    }
}
