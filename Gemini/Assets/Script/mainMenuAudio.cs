using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("mainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
