using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningEnemy : EnemyController
{
    //variables for moving
    public GameObject[] points;
    private int CurrentPoint = 0;
    public float speed;


    public float stoppingDistance;
    public GameObject player;
    private bool isShooting;
    public GameObject bullet;
    public Transform shootingPoint;
    public float shootingInterval = 2f;
    private float timeSinceLastShot = 0f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        isShooting = false;
        isFacingRight = false;
    }

    void Update()
    {
        if (!isShooting)
            Move();

        PlayerClose();
    }

    void Move()
    {
        //Runing state
        anim.SetBool("wait", false);
        anim.SetBool("Shoot", false);
        anim.SetBool("Run", true);

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

    void PlayerClose()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (checkIfFront() && distanceToPlayer <= stoppingDistance)
        {
            //Idel state
            anim.SetBool("wait", true);
            //anim.SetBool("Shoot", false);
            anim.SetBool("Run", false);

            isShooting = true;
            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot >= shootingInterval)
            {
                //Shooting state
                anim.SetBool("Shoot", true);
                anim.SetBool("wait", false);
                anim.SetBool("Run", false);

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
            anim.SetBool("Run", true);
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

    private void Shoot()
    {
        Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
    }

    private void StopShootingAnimation()
    {
        //Idel state
        anim.SetBool("wait", true);
        anim.SetBool("Shoot", false);
        anim.SetBool("Run", false);
    }
}
