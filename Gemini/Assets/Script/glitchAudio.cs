using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glitchAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("glitch");
        FindObjectOfType<AudioManager>().Play("glitchh");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
