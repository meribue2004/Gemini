using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float Yoffset;
    public  float zoom=8;
    private CameraController CC;

    void Start()
    {
        CC = FindObjectOfType<CameraController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CC.minX = minX;
            CC.minY = minY;
            CC.maxX = maxX;
            CC.maxY = maxY;
            CC.Yoffset = Yoffset;
            CC.CameraZoom(zoom);
        }
    }
}
