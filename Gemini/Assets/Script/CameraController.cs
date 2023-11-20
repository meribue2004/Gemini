using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The target to follow (your player)

    public float CameraSpeed; // How quickly the camera follows the target

    public float minX, maxX, minY, maxY;

    private void Start()
    {
    }

    private void Update()
    { 
    }
   void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 newCamPosition = Vector2.Lerp(transform.position, target.position, Time.deltaTime * CameraSpeed);

            //newCamPosition.y += 0.2f;


            float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY);
            transform.position = new Vector3(ClampX, ClampY,-10f);
        }
    }
}
