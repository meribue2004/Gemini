//using UnityEngine;
//using System.Collections;

//public class DisintegratingPlatform : MonoBehaviour
//{
//    public float fallDelay = 1f;
//    private float respawnDelay = 5f;
//    private Vector2 respawnPosition; // Set this to the position where the platform should respawn

//    private Rigidbody2D rb;
//    private Collider2D coll;

//    private void Start()
//    {
//        rb= this.GetComponent<Rigidbody2D>();
//        coll = GetComponent<Collider2D>();
//        respawnPosition = transform.position; // Store the initial position as the respawn position
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (!DialogueManager.isDialogueActive && !ChoicesBtn.isChoosing) {
//            if (collision.gameObject.CompareTag("Player"))
//            {
//                StartCoroutine(Fall());
//            } 
//        }
//    }

//    private IEnumerator Fall()
//    {
//        yield return new WaitForSeconds(fallDelay);
//        rb.bodyType = RigidbodyType2D.Dynamic;
//        coll.enabled = false;

//        // Wait for the platform to fall and then move it to the respawn position
//        yield return new WaitForSeconds(respawnDelay);
//        transform.position = respawnPosition;

//        // Reset the Rigidbody and Collider for the next use
//        rb.bodyType = RigidbodyType2D.Static;
//        coll.enabled = true;
//    }
//}

using UnityEngine;
using System.Collections;

public class DisintegratingPlatform : MonoBehaviour
{
    public float fallDelay = 10f;
    private float respawnDelay = 5f;
    private Vector2 respawnPosition; // Set this to the position where the platform should respawn

    private Rigidbody2D rb;
    private Collider2D coll;
    private Vector2 originalPosition; // Store the original position for shaking

    // Variables for shaking
    public float shakeMagnitude = 0.1f;
    public float shakeDuration = 10f;
    private bool shaking = false;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        respawnPosition = transform.position; // Store the initial position as the respawn position
        originalPosition = transform.position; // Store the initial position for shaking
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!DialogueManager.isDialogueActive && !ChoicesBtn.isChoosing)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(Fall());
            }
        }
    }

    private IEnumerator Fall()
    {
        // Shake the platform before falling
        if (!shaking)
        {
            shaking = true;
            StartCoroutine(Shake());
        }

        yield return new WaitForSeconds(shakeDuration);

        // Fall after the shaking
        rb.bodyType = RigidbodyType2D.Dynamic;
        coll.enabled = false;

        // Wait for the platform to fall and then move it to the respawn position
        yield return new WaitForSeconds(respawnDelay);
        transform.position = respawnPosition;

        // Reset the Rigidbody and Collider for the next use
        rb.bodyType = RigidbodyType2D.Static;
        coll.enabled = true;
    }

    private IEnumerator Shake()
    {
        float elapsedTime = 0f;
        while (elapsedTime < shakeDuration)
        {
            // Calculate the random shaking offset
            Vector2 shakeOffset = Random.insideUnitCircle * shakeMagnitude;

            // Apply the offset to the platform's position
            transform.position = originalPosition + shakeOffset;

            // Increase the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Reset the position after shaking
        transform.position = originalPosition;
        shaking = false;
    }
}
