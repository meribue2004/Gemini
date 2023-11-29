using UnityEngine;

public class DisintegratingPlatform : MonoBehaviour
{
    public float disintegrationTime = 3f;      // Time it takes for the platform to disintegrate
    public Material disintegratedMaterial;     // Material to apply after disintegration
    public float hopDurationThreshold = 0.5f;  // Minimum time the player needs to be on the platform to trigger disintegration

    private Material originalMaterial;
    private bool isDisintegrating = false;
    private float timeOnPlatform = 0f;

    private void Start()
    {
        // Assuming the platform has a SpriteRenderer component
        originalMaterial = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        if (isDisintegrating)
        {
            Disintegrate();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player has landed on the platform
            timeOnPlatform = 0f;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Increment the time the player has been on the platform
            timeOnPlatform += Time.deltaTime;

            // If the player has been on the platform for the specified duration, start disintegration
            if (timeOnPlatform >= hopDurationThreshold && !isDisintegrating)
            {
                StartDisintegration();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player has left the platform, reset the timer
            timeOnPlatform = 0f;
        }
    }

    private void StartDisintegration()
    {
        isDisintegrating = true;
        Invoke("CompleteDisintegration", disintegrationTime);
    }

    private void Disintegrate()
    {
        // Implement your disintegration logic here
        // For a simple example, you can change the material or scale of the platform over time
        float lerpValue = Mathf.PingPong(Time.time, disintegrationTime) / disintegrationTime;
        GetComponent<SpriteRenderer>().material.Lerp(originalMaterial, disintegratedMaterial, lerpValue);
    }

    private void CompleteDisintegration()
    {
        // Optionally, perform any cleanup or destruction logic here
        Destroy(gameObject);
    }
}
