using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class Button_hover : MonoBehaviour
{
    public Button[] buttons;

    private Dictionary<string, Button> keyValuePairs = new Dictionary<string, Button>();

    private void Start()
    {
        foreach(var button in buttons)
        {
            keyValuePairs[button.name] = button;
        }  
    }
    public void Button_Emphasizes(string name)
    {
        foreach (Button key in keyValuePairs.Values) 
        {
            if(key.name  == name)
            {
                key.transform.localScale = new Vector3(1.05f, 1.05f, 1f);  
            }
            
        }
    }
    public void Button_Un_Emphasizes(string name)
    {
        foreach (Button key in keyValuePairs.Values)
        {
            if (key.name == name)
            {
                key.transform.localScale = new Vector3(1f, 1f, 1f);
            }

        }
    }
}

