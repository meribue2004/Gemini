using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool isFacingRight = false;
    public int damageToPlayer=1;
    public EnemyHealthBar healthBar;
    public float HitPoints=3; // if hit 3 times they die
    public float MaxHitPoint = 3; // if hit 3 times they die
    public Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            FindObjectOfType<Healthstates>().TakeDamage(damageToPlayer);
        }
    }

    public void TakeHit(float damageTaken)
    {
        HitPoints -= damageTaken;
        healthBar.setHealth(HitPoints, MaxHitPoint);

        if (HitPoints <= 0)
        {
            StartCoroutine(DestroyAfterAnimation());
        }
    }

    IEnumerator DestroyAfterAnimation()
    {
        anim.SetTrigger("die");

        Debug.Log("Playing death animation");

        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        Destroy(gameObject);
    }
}

