using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasershot : MonoBehaviour
{
    public float moveSpeed = 10f; // Adjust the speed of the bullet
   
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
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
        //float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        //// Update the object's position directly
        //transform.position = new Vector3(
        //    transform.position.x + horizontalMovement,
        //    transform.position.y + verticalMovement,
        //    transform.position.z);
        //GetComponent<Rigidbody2D>().velocity=new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, -moveSpeed);


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Handle player damage
            FindObjectOfType<Healthstates>().TakeDamage(1);
            Destroy(gameObject);
        }
        if(other.tag == "Ground")
        {
            Destroy(gameObject);

        }

        // Destroy the bullet when it collides with something
     
    }
}

