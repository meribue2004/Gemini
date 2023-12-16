using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traplevel3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int damage = 1;
    void OnTriggerEnter2D(Collider2D collider)
    {


        if (collider.tag == "Player")
        {
            
            FindObjectOfType<Healthsytemlevel3>().TakeDamage(damage);
            //FindObjectOfType<LevelManager>().RespawnPlayer();
        }
    }
}
