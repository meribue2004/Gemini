
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standingEnemy2 : EnemyController
{
    private PlayerMovement player;
    public float shootingInterval = 5f;
    private float timeSinceLastShot = 0f;
    private bool onplayers = false;
    public GameObject bulletss;
    ShootingEnemy enemyController;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>();
    }

    public bool returnside() { return onplayers; }
    public void setside(bool side) { onplayers = side; }
    private void Update()
    {


        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= shootingInterval)
        {
            anim.SetBool("shooting", true);

            Invoke("Shootss", 1.5f);

            Invoke("StopShootingAnimation", 0.7f);

            timeSinceLastShot = 0f;
        }

        if ((player.transform.position.x < transform.position.x && isFacingRight) ||
         (player.transform.position.x > transform.position.x && !isFacingRight))
        {
            Flip();
        }

        //        else if (onplayers)
        //        {
        //Invoke("Flip",10f);
        //        }
    }

    private void StopShootingAnimation()
    {
        anim.SetBool("shooting", false);
    }

    public void Shootss()
    {

        GameObject bulletInstance = Instantiate(bulletss, shootingPoint.position, shootingPoint.rotation);
        BulletController bulletScript = bulletInstance.GetComponent<BulletController>();
        //bulletScript.sett(onplayers);
    }
}

