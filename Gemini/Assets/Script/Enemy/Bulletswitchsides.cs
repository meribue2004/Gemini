using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//switching side bullet called by key 'D'
public class Bulletswitchsides : PlayerBulletController
{
    ShootingEnemy Enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Enemy got Switched");
            Enemy = collision.GetComponent<ShootingEnemy>();

            if (Enemy != null)
            {
                Enemy.setside(true);
            }

            Destroy(gameObject);
        }
        if (collision.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }



}


