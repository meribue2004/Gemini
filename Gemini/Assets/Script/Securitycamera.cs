using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Securitycamera : MonoBehaviour
{

    public Transform player; // Reference to the player's transform

    public float detectionRadius = 0.1f;


    public float rotationSpeed = 30f; // Adjust the rotation speed as needed
    public Transform rotationCenter; // The center point around which the camera rotates
 private void Start()
    {
        FindObjectOfType<AudioManager>().Play("lvl1");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        // Check if the collider that touched the sprite is the player 
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("surveillance");
            player.GetComponent<Healthstates>().TakeDamage(6);
            FindObjectOfType<LevelManager>().RespawnPlayer();
        }
    }
    void RotateCamera() {

    float angle = Time.deltaTime * rotationSpeed;

    // Rotate the camera around the specified center point
    //transform.RotateAround(rotationCenter.position, Vector3.up, angle);
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}


