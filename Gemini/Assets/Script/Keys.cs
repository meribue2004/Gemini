using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public int coin_value;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            FindObjectOfType<Healthstates>().coinsCollected += coin_value;
        }
        Destroy(this.gameObject);
    }
}