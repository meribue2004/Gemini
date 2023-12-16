using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunpiecescollect : MonoBehaviour
{
    public float movementDistance = 1.0f; // The distance the object moves up and down
    public float movementSpeed = 4.0f; // The speed at which the object moves
    private Vector3 startPosition;
    public int gun;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the vertical movement using a sine wave
        float newY = startPosition.y + Mathf.Sin(Time.time * movementSpeed) * movementDistance;

        // Update the object's position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("guncollect");
            FindObjectOfType<jetpackmovment>().gunpiecescollcted();
            Destroy(this.gameObject);
        }
    }
}
