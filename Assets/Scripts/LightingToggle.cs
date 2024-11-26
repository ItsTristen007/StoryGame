using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingToggle : MonoBehaviour
{
    public Light[] lights;  // Array to store references to lights
    private bool lightsEnabled = true;  // Tracks whether lights are on or off

    void Start()
    {
        // Ensure lights are initially enabled
        SetLightingState(lightsEnabled);
    }

    void Update()
    {
        // Toggle the lights when the "L" key is pressed
        if (Input.GetKeyDown(KeyCode.L))
        {
            ToggleLights();
        }
    }

    void ToggleLights()
    {
        // Toggle the lighting state
        lightsEnabled = !lightsEnabled;
        
        // Apply the new state to all the lights in the array
        SetLightingState(lightsEnabled);
    }

    void SetLightingState(bool state)
    {
        // Iterate over all lights and set their enabled state
        foreach (Light light in lights)
        {
            if (light != null)
            {
                light.enabled = state;
            }
        }
    }
}
