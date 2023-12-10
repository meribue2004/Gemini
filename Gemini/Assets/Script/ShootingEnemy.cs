using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : EnemyController
{
    private Animator anim;
    private PlayerMovement player;
    public GameObject bullet;
    public Transform shootingPoint;
    public float shootingInterval = 5f;
    private float timeSinceLastShot = 0f;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootingInterval)
        {
            anim.SetBool("shooting", true);

            Invoke("Shoot", 0.5f);

            Invoke("StopShootingAnimation", 0.7f);

            timeSinceLastShot = 0f;
        }

        if ((player.transform.position.x < transform.position.x && isFacingRight) ||
         (player.transform.position.x > transform.position.x && !isFacingRight))
        {
            Flip();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
    }

    private void StopShootingAnimation()
    {
        anim.SetBool("shooting", false);
    }
}

