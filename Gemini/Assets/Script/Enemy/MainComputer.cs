using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainComputer : EnemyController
{

    public Sprite HalfHealth;
    public Sprite Death;
    private SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootingInterval)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }

        Health();
    }

    void Health()
    {
        //when reached half its health
        if ((MaxHealth / 2) == CurrentHealth)
        {
            Debug.Log("half health");
            sr.sprite = HalfHealth;
        }
        //when reached half its health
        if (CurrentHealth == 0)
        {
            sr.sprite = Death;
            Invoke("destory", 0.5f);
        }
    }

    //overriding the enemyController parent function since the logic is a bit different
    public override void TakeHit(float damageTaken)
    {
        CurrentHealth -= damageTaken;

        //updating the enemy's health bar
        healthBar.setHealth(CurrentHealth, MaxHealth);
    }

    void destory()
    {
        Destroy(this.gameObject);
    }
}
