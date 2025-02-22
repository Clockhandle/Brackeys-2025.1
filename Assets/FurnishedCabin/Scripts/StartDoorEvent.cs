using UnityEngine;

public class StartDoorEvent : MonoBehaviour
{
    private static int count = 0;
    private static bool isSpecialObject;

    public MoveObjectController controller;

    private void Start()
    {
        controller = GetComponent<MoveObjectController>();
        controller.boolSpecialObjectEvent = OpenDoor;
    }
    public static bool OpenDoor()
    {
        if (count <= 8)
        {
            isSpecialObject = true;
            count++;
        }
        else
        {
            isSpecialObject = false;
        }
        return isSpecialObject;
    }
}