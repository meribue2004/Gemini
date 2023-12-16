using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKit : MonoBehaviour
{
    public float time=30;
    //public float timetoadd = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //FindObjectOfType<Timer>().IncreaseTotalTime(timetoadd);
    }
  
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("time");
      
            FindObjectOfType<Healthstates>().inctime();
        }
        Destroy(this.gameObject);
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        // Increment player's total time when the player collects the time kit
    //        Timer player = other.GetComponent<Timer>(); // Assuming you have a script for player control
    //        if (player != null)
    //        {
    //            player.IncreaseTotalTime(timetoadd);
    //            Destroy(gameObject); // Destroy the time kit object after collecting
    //        }
    //    }
    //}
}
