using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowOpacity : MonoBehaviour
{
    private SpriteRenderer mySprite;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        originalColor = mySprite.color; // Store the original color
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any update logic here if needed
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SetOpacity(0.5f);
            FindObjectOfType<CameraController>().maxX=610;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ResetOpacity();
        }
    }

    private void SetOpacity(float opacity)
    {
        Color newColor = originalColor;
        newColor.a = opacity; // Set the alpha (transparency) component of the color
        mySprite.color = newColor;
    }

    private void ResetOpacity()
    {
        mySprite.color = originalColor; // Reset the color to the original color
    }
}
