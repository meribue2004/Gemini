using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laserstops : MonoBehaviour
{
    private Collider[] colliders;
    private BoxCollider2D boxCollider; 

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        // Get all colliders attached to this GameObject
        colliders = GetComponentsInChildren<Collider>();

        // Start the coroutine to toggle visibility every 3 seconds
        StartCoroutine(ToggleVisibilityRoutine());
    }

    IEnumerator ToggleVisibilityRoutine()
    {
        while (true)
        {
            // Hide the GameObject (disable colliders and set as trigger)
            SetVisibility(false, true);
            if(boxCollider!=null)
            {
                boxCollider.enabled = false;
            }

            // Wait for 3 seconds
            yield return new WaitForSeconds(3f);

            // Show the GameObject (enable colliders and set as non-trigger)
            SetVisibility(true, false);
            if(boxCollider!=null)
            {
                boxCollider.enabled = true;
            }

            // Wait for 3 seconds before toggling visibility again
            yield return new WaitForSeconds(3f);
        }
    }

    void SetVisibility(bool isVisible, bool isTrigger)
    {
        // Loop through all the colliders and enable/disable them based on visibility
        foreach (Collider collider in colliders)
        {
            collider.enabled = isVisible;
            collider.isTrigger = isTrigger;
        }

        // Set the GameObject's renderer visibility accordingly (optional)
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = isVisible;
        }
    }
}
