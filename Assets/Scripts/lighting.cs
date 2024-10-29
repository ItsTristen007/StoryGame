using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class lighting : MonoBehaviour
{
    public Material material;

    void Update()
    {
        // Example: Set light direction
        Vector3 lightDirection = new Vector3(0, -1, -1).normalized; // Example direction
        material.SetVector("_LightDirection", lightDirection);

        // Example: Set ambient color
        Color ambientColor = new Color(0.2f, 0.2f, 0.2f, 1); // Example ambient color
        material.SetColor("_AmbientColor", ambientColor);
    }
}
