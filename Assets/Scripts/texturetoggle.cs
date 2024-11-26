using UnityEngine;

public class texturetoggle : MonoBehaviour
{
    public Material material1;  // The first material to toggle to
    public Material material2;  // The second material to toggle to
    private bool isMaterial1Active = true;  // Tracks which material is currently active
    private Renderer objectRenderer;

    void Start()
    {
        // Get the Renderer component of the object
        objectRenderer = GetComponent<Renderer>();

        // Make sure we have the first material initially
        if (material1 != null)
        {
            objectRenderer.material = material1;
        }
    }

    void Update()
    {
        // Toggle materials when the "T" key is pressed
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleMaterial();
        }
    }

    void ToggleMaterial()
    {
        // Switch between materials based on the current active material
        if (isMaterial1Active)
        {
            if (material2 != null)
            {
                objectRenderer.material = material2;  // Change to material2
            }
        }
        else
        {
            if (material1 != null)
            {
                objectRenderer.material = material1;  // Change back to material1
            }
        }

        // Flip the active material state
        isMaterial1Active = !isMaterial1Active;
    }
}