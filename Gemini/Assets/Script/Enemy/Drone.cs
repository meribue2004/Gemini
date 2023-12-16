using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : EnemyController
{
    //variables for moving
    public GameObject[] points;
    private int CurrentPoint = 0;
    public float speed;
    public float timer = 0;

    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        move();

        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bullet, shootingPoint.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("droneshot");
    }

    public void move()
    {
        if (Vector2.Distance(points[CurrentPoint].transform.position, transform.position) < 0.1f)
        {
            Flip();
            CurrentPoint++;
            if (CurrentPoint >= points.Length)
            {
                CurrentPoint = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[CurrentPoint].transform.position, Time.deltaTime * speed);
    }

}
