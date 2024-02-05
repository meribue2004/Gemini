//using UnityEngine;
//using System.Collections;
//public class DisintegratingPlatform : MonoBehaviour
//{
//    public float fallDelay = 1f;
//    private float destroyDelay = 2f;

//    [SerializeField] private Rigidbody2D rb;//reference platform's rigidbody2d

//    private void OnCollisionEnter2D(Collision2D collision)//check if player collide with platform
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            StartCoroutine(Fall());//cause fall
//        }
//    }

//    private IEnumerator Fall()
//    {
//        yield return new WaitForSeconds(fallDelay);//wait for a while before the platform falls
//        rb.bodyType = RigidbodyType2D.Dynamic;//falls
//        Destroy(gameObject, destroyDelay);//dont want platform to fall forever, destroy after a time
//    }
//}

using UnityEngine;
using System.Collections;

public class DisintegratingPlatform : MonoBehaviour
{
    public float fallDelay = 1f;
    private float respawnDelay = 5f;
    private Vector2 respawnPosition; // Set this to the position where the platform should respawn

    private Rigidbody2D rb;
    private Collider2D coll;

    private void Start()
    {
        rb= this.GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        respawnPosition = transform.position; // Store the initial position as the respawn position
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!DialogueManager.isDialogueActive && !ChoicesBtn.isChoosing) {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(Fall());
            } 
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        coll.enabled = false;

        // Wait for the platform to fall and then move it to the respawn position
        yield return new WaitForSeconds(respawnDelay);
        transform.position = respawnPosition;

        // Reset the Rigidbody and Collider for the next use
        rb.bodyType = RigidbodyType2D.Static;
        coll.enabled = true;
    }
}

