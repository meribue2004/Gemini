using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheel : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))  // Replace "Enemy" with the tag of your enemy GameObject
        {
            // Optionally, you can add logic here for enemy damage or other effects.

            // Disable or destroy the bullet GameObject.
            gameObject.SetActive(false);
            // Alternatively, you can use Destroy(gameObject) if you want to completely remove the GameObject.
            // Destroy(gameObject);
        }
    }
}
