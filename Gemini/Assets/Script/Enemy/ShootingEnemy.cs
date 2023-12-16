using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : EnemyController
{   
    private bool onPlayersSide = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //Switching side codes
    public bool returnside() 
    { 
        return onPlayersSide; 
    }

    public void setside(bool side) {
        onPlayersSide = side;
        Debug.Log("Enemy got switched");
    }

    private void Update()
    {
        if (!DialogueManager.isDialogueActive)
        {
            //shooting
            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot >= shootingInterval)
            {

                anim.SetBool("shooting", true);

                Invoke("Shoot", 0.5f);

                Invoke("StopShootingAnimation", 0.7f);

                timeSinceLastShot = 0f;
            }

            //Fliping the position of the enemy based on the position of the player
            if ((player.transform.position.x < transform.position.x && isFacingRight) ||
             (player.transform.position.x > transform.position.x && !isFacingRight))
            {
                Flip();
            }
        }
    }

    private void StopShootingAnimation()
    {
        anim.SetBool("shooting", false);
    }

    public new void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
        EnemyBullet bulletScript = bulletInstance.GetComponent<EnemyBullet>();

        // Pass a reference to the ShootingEnemy script
        bulletScript.SetShootingEnemy(this);
        FindObjectOfType<AudioManager>().Play("enemyweapon");
    }
}

