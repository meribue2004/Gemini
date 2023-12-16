using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public bool isFacingRight = true;
    public float bulletSpeed;
    private Animator anim;
    public int damage;
    private Transform player;
    private bool onplayerside;
    private ShootingEnemy shootingEnemy;
    public bool GoldenRobot;

    private void Start()
    {
        onplayerside = false;
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>().transform;
        SetInitialDirection();
    }

    void Update()
    {
        //only the golden robot can be switched shids
        if (GoldenRobot)
        {
            //checking is the enemy is on the player's side, so that if they are the bullet wont hurt the player
            onplayerside = shootingEnemy.returnside();
        }

        //movement only x, y is constant
        GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShootingEnemy collidedScript = collision.GetComponent<ShootingEnemy>();
        Healthstates collidedScript2 = collision.GetComponent<Healthstates>();
      
         if (collision.tag == "Enemy" && onplayerside)
        {
            StopBullet();
            collidedScript.TakeHit(damage);
        }
        if (collision.tag == "Player" && !(onplayerside))
        {
            StopBullet();
            collidedScript2.TakeDamage(damage);
        }
        else if (collision.tag == "shield" || collision.tag == "Ground")
        {

            //StopBullet();
            Destroy(this.gameObject);
        }
    }

    //bullet stops moving and plays the Destroy animation
    private void StopBullet()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Stop the bullet by setting verlocity to 0
        StartCoroutine(DestroyAfterAnimation());
    }

    //bullet gets destroyed after the destroy animation
    IEnumerator DestroyAfterAnimation()
    {
        anim.SetBool("hit", true);

        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        Destroy(gameObject);
    }

    //sets the direction of the bullet based on the players direction
    private void SetInitialDirection()
    {
        if (player.position.x > transform.position.x)
        {
            //player to the right, move in positive direction ->
            bulletSpeed = Mathf.Abs(bulletSpeed);
        }
        else
        {
            //player to the left, move in negative direction <-
            bulletSpeed = -Mathf.Abs(bulletSpeed);
        }

        if ((player.position.x > transform.position.x && !isFacingRight) ||
          (player.position.x < transform.position.x && isFacingRight))
        {
            Flip();
        }
    }
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    public void SetShootingEnemy(ShootingEnemy enemy)
    {
        shootingEnemy = enemy;
        onplayerside = shootingEnemy.returnside();
    }
}
