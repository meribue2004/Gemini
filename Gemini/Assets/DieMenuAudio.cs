using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieMenuAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("key");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
