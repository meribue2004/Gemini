using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningEnemy : EnemyController
{
    //variables for moving
    public GameObject[] points;
    private int CurrentPoint = 0;
    public float speed;

    //variables for shooting
    public float stoppingDistance;
    private bool isShooting;

    private void Start()
    {
        anim = GetComponent<Animator>();
        isShooting = false;
        //isFacingRight = false;
    }

    void Update()
    {
        //only move if the enemy is not shooting the player
        if (!isShooting)
            Move();

        //Checking if player is close, if yes the enemy starts shooting, if no they continue moving
        PlayerClose();
    }

    void Move()
    {
        //Runing state
        anim.SetBool("wait", false);
        anim.SetBool("Shoot", false);

        //check the distance between the enemy's location and the point he should go to,
        //if this distance is small we assume he reached it so he starts moving to the next point and flips direction
        if (Vector2.Distance(points[CurrentPoint].transform.position, transform.position) < 0.1f)
        {
            Flip();
            CurrentPoint++; //updating the point the enemy is at right now

            //He has reached the last point, start going to the first point again
            if (CurrentPoint >= points.Length)
            {
                CurrentPoint = 0;
            }
        }

        //movemment from his current position to the point he needs to go to
        transform.position = Vector2.MoveTowards(transform.position, points[CurrentPoint].transform.position, Time.deltaTime * speed);
    }

    void PlayerClose()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        //if this distance is close enough and the player is standing in front of the enemy
        //the enemy will stop moving and start shooting
        if (checkIfFront() && distanceToPlayer <= stoppingDistance)
        {
            //Idel state
            anim.SetBool("wait", true);
            isShooting = true;

            //shoot every 5 seconds
            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot >= shootingInterval)
            {
                //Shooting state
                anim.SetBool("Shoot", true);
                anim.SetBool("wait", false);

                Invoke("Shoot", 0.5f);
                Invoke("StopShootingAnimation", 0.7f);
                timeSinceLastShot = 0f;
            }
        }
        else
        {
            //Running state
            isShooting = false;
            anim.SetBool("wait", false);
            anim.SetBool("Shoot", false); 
        }
    }
    
    //checking if the player is in front of the robot
    bool checkIfFront()
    {
        float playerX = player.transform.position.x;
        float enemyX = transform.position.x;

        if ((isFacingRight && playerX > enemyX) || (!isFacingRight && playerX < enemyX))
            return true;
        else
            return false;
    }


    private void StopShootingAnimation()
    {
        //Idel state
        anim.SetBool("wait", true);
        anim.SetBool("Shoot", false);
    }
}
