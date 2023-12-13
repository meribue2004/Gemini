using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletswitchsides : MonoBehaviour
{
  

    // Update is called once per frame
 

    public float speed;
    ShootingEnemy enemyController;

    void Start()
    {
        PlayerMovement player;
        player = FindObjectOfType<PlayerMovement>();

        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
            transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }
    public ShootingEnemy returnswitchedenemy()
    {
        return enemyController;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Enemy got hit");
             enemyController = collision.GetComponent<ShootingEnemy>();
           // FindObjectOfType<BulletController>().seteem(enemyController);

            if (enemyController != null)
            {
                // Call the TakeHit function on the specific enemy
                enemyController.setside(true);
            }

            Destroy(gameObject);
        }
    }



}


