//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class rotateplanet : MonoBehaviour
//{
//    //public float rotationSpeed = 45f; // Adjust the rotation speed as needed

//    //private float timeCounter = 0f;

//    //void Update()
//    //{
//    //    // Increase the time counter based on Time.deltaTime
//    //    timeCounter += Time.deltaTime;

//    //    // Calculate the new position using trigonometric functions
//    //    float x = Mathf.Cos(timeCounter * rotationSpeed) * 1f; // Radius is 5, adjust as needed
//    //    float y = Mathf.Sin(timeCounter * rotationSpeed) * 1f;

//    //    // Set the new position
//    //    transform.position = new Vector3(x, y, 0f);
//    //}
//    public Transform rotationCenter; // The center point around which the camera rotates
//    public float rotationSpeed = 50f; // Speed of the rotation
//    public float amplitude = 438.4f;    // Amplitude of the oscillation

//    // Update is called once per frame
//    void Update()
//    {
//        // Calculate the X and Y values based on sine functions
//        float xValue = amplitude * Mathf.Sin(rotationSpeed * Time.time);
//        float yValue = amplitude * Mathf.Cos(rotationSpeed * Time.time);

//        // Set the object's position
//        transform.position = new Vector3(xValue, yValue, 0f);
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateplanet : MonoBehaviour
{
    public Transform rotationCenter; // The center point around which the moon rotates (Earth)
    public float rotationSpeed = 50f; // Speed of the rotation
    public float radius = 25f;    // Radius of the circular orbit

    // Update is called once per frame
    void Update()
    {
        // Calculate the angle based on time and rotation speed
        float angle = Time.time * rotationSpeed;

        // Calculate the new position using trigonometric functions (circular motion)
        float x = rotationCenter.position.x + Mathf.Cos(angle) * radius;
        float y = rotationCenter.position.y + Mathf.Sin(angle) * radius;

        // Set the object's position
        transform.position = new Vector3(x, y, 0f);
    }
}
