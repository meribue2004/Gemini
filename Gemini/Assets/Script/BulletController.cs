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

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>().transform;
        SetInitialDirection();
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<Healthstates>().TakeDamage(damage);
            StartCoroutine(DestroyAfterAnimation());
        }
        else if (collision.tag == "Ground")
        {
            StartCoroutine(DestroyAfterAnimation());
        }
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
