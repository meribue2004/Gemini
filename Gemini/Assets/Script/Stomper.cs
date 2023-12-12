using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
 
    public float amplitude = 1.0f;   
    public float frequency = 1.0f;
    public bool stomper2 = false;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        if (stomper2)
        {

            Invoke("MoveUpDown", 8.0f);
        }
        

        StartCoroutine(MoveUpDown());
    }

    IEnumerator MoveUpDown() { 
   

    while (true)
        {
            
            float newY = startPos.y + amplitude * Mathf.Sin(frequency * Time.time);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            yield return null;
        }
    }
}
