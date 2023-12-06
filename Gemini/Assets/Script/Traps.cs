using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public int damage = 1;
    void OnTriggerEnter2D(Collider2D collider)
    {


        if (collider.tag == "Player")
        {
            FindObjectOfType<Healthstates>().TakeDamage(damage);
        }
    }
}
