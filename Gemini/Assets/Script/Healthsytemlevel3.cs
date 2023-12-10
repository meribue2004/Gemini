using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthsytemlevel3 : MonoBehaviour
{
  
    public int health = 6;
    public int lives = 3;

    private SpriteRenderer spriteRenderer;

    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;

    private Animator anim;
    private bool hurt;
    private bool died = false;

    void Start()
    {
        //spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (this.isImmune == true)
        {
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
              
                this.isImmune = false;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        if (!this.isImmune)
        {
            hurt = true;
           
            this.health = this.health - damage;
            if (this.health < 0)
            {
                this.health = 0;
            }
            if (this.lives > 0 && this.health == 0)
            {
                died = true;
           
                FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health = 6;
                this.lives--;
            }
            else if (this.health == 0 && this.lives == 0)
            {
                Debug.Log("Gameover");
                Destroy(this.gameObject); // Destroy the object when no lives left and health is zero
            }
            Debug.Log("Player health:" + this.health.ToString());
            Debug.Log("Player Lives:" + this.lives.ToString());

            PlayHitReaction();
        }
    }

    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }
    public void Decreaselives()
    {
        this.lives--;

      
        WaitAndContinue();
        if (this.health > 0 || this.lives > 0)
        {
            FindObjectOfType<LevelManager>().RespawnPlayer();
        }

        else if (this.health == 0 && this.lives == 0)
        {
            Debug.Log("Gameover");
            Destroy(this.gameObject); // Destroy the object when no lives left and health is zero
        }

        Debug.Log("Player health:" + this.health.ToString());
        Debug.Log("Player Lives:" + this.lives.ToString());

        PlayHitReaction();
    }
    IEnumerator WaitAndContinue()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(3f);
    }


}


