using UnityEngine;

public class UnfinishedDoor : MonoBehaviour
{
    public static int unfinishedDoorCount = 0;

    private static bool isSpecialObject;

    public MoveObjectController controller;

    private void Start()
    {
        controller = GetComponent<MoveObjectController>();
        controller.boolSpecialObjectEvent = OnDoubleDoorTriggered;
    }
    public bool OnDoubleDoorTriggered()
    {
        if (unfinishedDoorCount >= 2)
        {
            isSpecialObject = false;
        }
        else
        {
            isSpecialObject = true;
        }
        unfinishedDoorCount++;
        return isSpecialObject;
    }
}
