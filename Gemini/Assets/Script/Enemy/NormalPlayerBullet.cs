using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//normal bullet called by key 'F'
public class NormalPlayerBullet : PlayerBulletController
{
    public float damage=1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Enemy got hit");
            //setting the specific instance of the enemy that the bullet collided with
            EnemyController enemyController = collision.GetComponent<EnemyController>();

            if (enemyController != null)
            {
                // Call the TakeHit function on that specific enemy
                enemyController.TakeHit(damage);
            }
            //destroy the bullet after it hits the enemy
            Destroy(gameObject);
        }
        if(collision.tag=="Main Computer")
        {
            MainComputer mainComp = collision.GetComponent<MainComputer>();

            if (mainComp != null)
            {
                mainComp.TakeHit(damage);
            }
            Destroy(gameObject);
        }
        //destroy the bullet if it hits the ground as well
        if (collision.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }

}
