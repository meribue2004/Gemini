using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningEnemy : EnemyController
{
    //variables for moving
    public GameObject[] points;
    private int CurrentPoint = 0;
    public float speed = 2f;

    //shooting related variables
    public float stoppingDistance = 10.0f;
    private Animator anim;
    public GameObject player;
    private bool isShooting;
    private bool isPlayerInFront;
    public GameObject bullet;
    public Transform shootingPoint;
    public float shootingInterval = 2f;
    private float timeSinceLastShot = 0f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        isShooting = false;
        isPlayerInFront = false;
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
        anim.SetBool("Shoot", isShooting);
        anim.SetBool("wait", false);
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

        checkIfFront();
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (isPlayerInFront && distanceToPlayer <= stoppingDistance)
        {
            anim.SetBool("wait", true);
            isShooting = true;
            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot >= shootingInterval)
            {
                anim.SetBool("Shoot", isShooting);
                anim.SetBool("wait", false);
                Invoke("Shoot", 0.5f);
                Invoke("StopShootingAnimation", 0.7f);
                timeSinceLastShot = 0f;
            }
        }
        else
        {
            isShooting = false;
            anim.SetBool("Shoot", isShooting);
        }
    }

    void checkIfFront()
    {
        //checking if the player is in front of the robot
        float playerX = player.transform.position.x;
        float enemyX = transform.position.x;

        if ((isFacingRight && playerX > enemyX) || (!isFacingRight && playerX < enemyX))
        {
            isPlayerInFront = true;
        }
        else
        {
            isPlayerInFront = false;
        }
    }
    private void Shoot()
    {
        Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
    }

    private void StopShootingAnimation()
    {
        anim.SetBool("wait", true);
        anim.SetBool("Shoot", false);
    }
}
