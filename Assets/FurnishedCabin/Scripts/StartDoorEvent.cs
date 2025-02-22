using UnityEngine;

public class StartDoorEvent : MonoBehaviour
{
    private static int count = 0;
    private static bool isSpecialObject;
    public static bool OpenDoor()
    {
        //switch(count)
        //{
        //    case 0:
        //        Debug.Log("The door is locked!");
        //        isSpecialObject = true;
        //        break;
        //    case 1:
        //        Debug.Log("The door is locked!");
        //        isSpecialObject = true;
        //        break;
        //    case 2:
        //        Debug.Log("The door is locked man!");
        //        isSpecialObject = true;
        //        break;
        //    case 3:
        //        Debug.Log("I said the door is-");
        //        isSpecialObject = true;
        //        break;
        //    case 4:
        //        Debug.Log("...");
        //        isSpecialObject = true;
        //        break;
        //    case 5:
        //        isSpecialObject = false;
        //        Debug.Log("...it's a pull door.");
        //        break;
        //}
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