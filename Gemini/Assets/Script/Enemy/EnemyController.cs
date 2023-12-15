using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool isFacingRight = false;
    public int damageToPlayer = 1;
    public EnemyHealthBar healthBar;
    public float CurrentHealth=3;
    public float MaxHealth = 3; // if hit 3 times they die
    protected Animator anim;
    public GameObject bullet;
    public Transform shootingPoint;
    public PlayerMovement player; //we find the player to know his position
    public float shootingInterval = 5f; //shoots every seconds
    protected float timeSinceLastShot = 0f; //counter for the shots

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
}

    //If the player touches the enemy they get hurt
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //function TakeDamage in the player's Healthstates decreases his health by a certain amount
            FindObjectOfType<Healthstates>().TakeDamage(damageToPlayer);
        }
    }
  
    //if a Player's bullet hits the enemy he losses health  
    public virtual void TakeHit(float damageTaken)
    {
        CurrentHealth -= damageTaken;

        //updating the enemy's health bar
        healthBar.setHealth(CurrentHealth, MaxHealth);

        //when the enemy's life is 0 he dies
        if (CurrentHealth <= 0)
        {
            StartCoroutine(DestroyAfterAnimation());
        }
    }

    //Dying after the die animation plays
    IEnumerator DestroyAfterAnimation()
    {
        anim.SetTrigger("die");

        Debug.Log("Playing death animation");

        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        Destroy(gameObject);
    }

    //Creating an Enemy bullet instance
    public void Shoot()
    {
        Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

}

