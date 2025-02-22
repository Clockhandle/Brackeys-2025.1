using UnityEngine;

public class KeyTaken : MonoBehaviour
{
    public MoveObjectController controller;

    private void Start()
    {
        controller.boolSpecialObjectEvent = TakeKey;
    }

    public bool TakeKey()
    {
        PlayerState.HasKey = true;
        gameObject.SetActive(false);
        return false;
    }
}
