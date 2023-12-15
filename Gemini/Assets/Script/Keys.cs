using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);

            FindObjectOfType<Healthstates>().CollectCoin();
        }

    }
}