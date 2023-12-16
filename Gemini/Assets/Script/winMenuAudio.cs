using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winMenuAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("lullaby");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
