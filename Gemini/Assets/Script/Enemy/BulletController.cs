using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public bool isFacingRight = true;
    public float bulletSpeed;
    private Animator anim;
    public int damage;
    private Transform player;
    private bool GotHit;
    public bool onplayerside;
    ShootingEnemy enemyController;
    private ShootingEnemy shootingEnemy;
    public bool GoldenRobot;

    private void Start()
    {
        onplayerside = false;
        GotHit = false;
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>().transform;
        SetInitialDirection();
    }

    void Update()
    {
      //bullet did not collide with anything
        if (!GotHit)
        {
            if(GoldenRobot)
                onplayerside = shootingEnemy.returnside();

            GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GotHit) return; // Ignore collisions if the bullet has already hit something
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
        if (collision.tag == "shield")
        {
            StopBullet();
        }
        else if (collision.tag == "Ground")
        {
            StopBullet();
        }
    }
    public void SetShootingEnemy(ShootingEnemy enemy)
    {
        shootingEnemy = enemy;
        onplayerside = shootingEnemy.returnside();
    }

    private void StopBullet()
    {
        GotHit = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Stop the bullet
        StartCoroutine(DestroyAfterAnimation());
    }

    IEnumerator DestroyAfterAnimation()
    {
        anim.SetBool("hit", true);

        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        Destroy(gameObject);
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
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
}
