using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public float damage=1;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Enemy got hit");
            EnemyController enemyController = collision.GetComponent<EnemyController>();

            if (enemyController != null)
            {
                // Call the TakeHit function on the specific enemy
                enemyController.TakeHit(damage);
            }

            Destroy(gameObject);
        }
    }

   

}
