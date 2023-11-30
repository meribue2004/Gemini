using UnityEngine;
using System.Collections;
public class DisintegratingPlatform : MonoBehaviour
{
    private float fallDelay = 1f;
    private float destroyDelay = 2f;

    [SerializeField] private Rigidbody2D rb;//reference platform's rigidbody2d

    private void OnCollisionEnter2D(Collision2D collision)//check if player collide with platform
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());//cause fall
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);//wait for a while before the platform falls
        rb.bodyType = RigidbodyType2D.Dynamic;//falls
        Destroy(gameObject, destroyDelay);//dont want platform to fall forever, destroy after a time
    }
}
