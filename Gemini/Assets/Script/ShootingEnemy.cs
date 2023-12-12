using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : EnemyController
{
    private PlayerMovement player;
    public float shootingInterval = 5f;
    private float timeSinceLastShot = 0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>();
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

    private void StopShootingAnimation()
    {
        anim.SetBool("shooting", false);
    }


}

