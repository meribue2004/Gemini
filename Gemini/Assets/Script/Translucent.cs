using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Translucent : MonoBehaviour
{
    private SpriteRenderer renderer; 
    private Color originalColor; //Refrence to the objects color
    private BoxCollider2D boxCollider; // Reference to the 2D Box Collider
    public float translucentAlpha = 0.2f; // Set the translucent alpha value
    private Color translucentColor; // Color in translucent state
    private float timer = 0f;
    public float translucentDuration = 5f; // Duration of the translucent state 
    public float opaqueDuration = 5f; // Duration of the opaque state

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        originalColor = renderer.color;
        boxCollider = GetComponent<BoxCollider2D>();
        translucentColor = new Color(originalColor.r, originalColor.g, originalColor.b, translucentAlpha);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer < translucentDuration)
        {
            renderer.color = translucentColor;

            // Disable the 2D Box Collider if making translucent
            if (boxCollider != null)
            {
                boxCollider.enabled = false;
            }
        }
        else if (timer < translucentDuration + opaqueDuration)
        {
            renderer.color = originalColor;

            // Enable the 2D Box Collider if returning to normal
            if (boxCollider != null)
            {
                boxCollider.enabled = true;
            }
        }
        else
        {
            timer = 0f;
        }
    }
}

