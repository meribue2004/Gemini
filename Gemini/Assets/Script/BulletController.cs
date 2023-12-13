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
    private bool GotHit = false;
    private bool onplayerside=false;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>().transform;
        SetInitialDirection();
    }

    void Update()
    {
       onplayerside= FindObjectOfType<EnemyController>().returnside();

        if (!GotHit)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GotHit) return; // Ignore collisions if the bullet has already hit something

        if (collision.tag == "Player" && !(onplayerside))
        {
            StopBullet();
            FindObjectOfType<Healthstates>().TakeDamage(damage);
        }
        else if (collision.tag == "Enemy" && onplayerside)
        {
            StopBullet();
            FindObjectOfType<EnemyController>().TakeHit(damage);
        }
        else if (collision.tag == "Ground")
        {
            StopBullet();
        }
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
    private void SetInitialDirection()
    {
        if (player.position.x > transform.position.x)
        {
            bulletSpeed = Mathf.Abs(bulletSpeed);
        }
        else
        {
            bulletSpeed = -Mathf.Abs(bulletSpeed);
        }

        if ((player.position.x > transform.position.x && !isFacingRight) ||
          (player.position.x < transform.position.x && isFacingRight))
        {
            Flip();
        }
    }
}
