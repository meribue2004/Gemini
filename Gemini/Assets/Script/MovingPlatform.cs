using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject[] points;
    private int CurrentPoint = 0;
    public float speed = 2f;
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(points[CurrentPoint].transform.position, transform.position) < 0.1f)
        {
            CurrentPoint++;
            if (CurrentPoint >= points.Length)
            {
                CurrentPoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[CurrentPoint].transform.position, Time.deltaTime*speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
