using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
    public static int countForSwitch = 0;
    private static bool isSpecialObject;

    public MoveObjectController controller;

    public List<Light> pointLights;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        controller = GetComponent<MoveObjectController>();
        controller.boolSpecialObjectEvent = FlipAndSwitchLights;
    }

    // Update is called once per frame
    public bool FlipAndSwitchLights()
    {
        // Increment switch count and determine special object state
        isSpecialObject = (++countForSwitch <= 4);

        // Toggle lights based on count
        for (int i = 0; i < pointLights.Count; i++)
        {
            if (countForSwitch >= 3)
            {
                pointLights[i].enabled = true;  // Turn all lights on
            }
            else
            {
                if (i == 4) continue; // Skip the 5th light (index 4)
                pointLights[i].enabled = false; // Turn off other lights
            }
        }

        return isSpecialObject;
    }
}
