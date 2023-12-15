using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject[] points; //array to store the points where the platform will move to or from
    private int CurrentPoint = 0; //a counter for these points, to track at which point is the platform at
    public float speed = 2f;
    
    void Update()
    {
        if (!DialogueManager.isDialogueActive)
        {
            //used to check that the platform had reached the current point, by comparing the distance between the platform and the point
            if (Vector2.Distance(points[CurrentPoint].transform.position, transform.position) < 0.1f)
            {
                CurrentPoint++;//when it reaches we increment CurrentPoint to say at which point we are at
                if (CurrentPoint >= points.Length)
                {
                    CurrentPoint = 0;// when it reachs the last point aka "points.Lenght" it will start agian from point 0
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, points[CurrentPoint].transform.position, Time.deltaTime * speed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
