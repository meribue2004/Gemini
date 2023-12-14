using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatearoundself : MonoBehaviour
{

    public float rotationSpeed = 45f; // Adjust the rotation speed as needed

    // Update is called once per frame
    void Update()
    {
        // Rotate the planet around its own center in the z-axis
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }


}
