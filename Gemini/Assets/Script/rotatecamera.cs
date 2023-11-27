using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatecamera : MonoBehaviour
{
    
    public Transform rotationCenter; // The center point around which the camera rotates
    public float rotationSpeed = 50f; // Speed of the rotation
    public float amplitude = 90f;    // Amplitude of the oscillation
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float angle = Time.deltaTime * rotationSpeed;

        //// Rotate the camera around the specified center point
        //transform.RotateAround(rotationCenter.position, Vector3.up, angle);
   

  
        // Calculate the Z value based on a sine function
        float zValue = amplitude * Mathf.Sin(rotationSpeed * Time.time);

        // Set the object's rotation
        transform.rotation = Quaternion.Euler(0f, 0f, zValue);
    
}
}
