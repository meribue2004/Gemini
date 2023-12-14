using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCompletion : MonoBehaviour
{
    public GameObject completeGun;
    public static int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(counter==5)
        {
            completeGun.SetActive(true);
        }
    }
}
