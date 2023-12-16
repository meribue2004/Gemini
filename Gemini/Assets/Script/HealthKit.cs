using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{
    public int heart;
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
        if (other.tag == "Player")
        {
            
            FindObjectOfType<Healthstates>().heartscollected += heart;
            FindObjectOfType<Healthstates>().ResetHealth();
            Destroy(this.gameObject);
             FindObjectOfType<AudioManager>().Play("health");
        }
        //Destroy(this.gameObject);
    }
}
