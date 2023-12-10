using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasershot : MonoBehaviour
{
    public float moveSpeed = 10f; // Adjust the speed of the bullet
   
    private Vector3 startPosition;
    public float targetZ = -36f;
    public Vector3 targetRotation = new Vector3(0f, 0f, -37f);
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(targetRotation);
        lasergun gun;
        gun = FindObjectOfType<lasergun>();
        // Save the initial position for shake effects
        startPosition = transform.position;

        // Destroy the bullet after 2 seconds
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
       
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, -moveSpeed);


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Handle player damage
            FindObjectOfType<Healthsytemlevel3>().TakeDamage(1);
            Destroy(gameObject);
        }
        if(other.tag == "Ground")
        {
            Destroy(gameObject);

        }

        // Destroy the bullet when it collides with something
     
    }
}

