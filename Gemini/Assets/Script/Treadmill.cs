using UnityEngine;

public class Treadmill : MonoBehaviour
{
    public float treadmillSpeed = 3f; // Adjust the treadmill speed as needed

 private void Start()
    {
        FindObjectOfType<AudioManager>().Play("lvl2");
    }
    void Update()
    {
        // Move the player to the left (treadmill direction) only if it's on the treadmill
        if (transform.childCount > 0)
        {
            Transform player = transform.GetChild(0); // Assuming the player is the first child
            player.Translate(Vector3.left * treadmillSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Assuming "Player" is the tag of the player GameObject
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
