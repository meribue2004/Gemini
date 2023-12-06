//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class Healthstates : MonoBehaviour
//{
//    public int health = 6;
//    public int lives = 3;

//    private Animator anim;
//    private bool hurt;
//    private bool died = false;

//    public bool isImmune = false;
//    private float immunityTime = 0f;
//    public float immunityDuration = 1.5f;

//    void Start()
//    {
//        anim = GetComponent<Animator>();
//    }

//    void Update()
//    {
//        if (isImmune)
//        {
//            immunityTime += Time.deltaTime;
//            if (immunityTime >= immunityDuration)
//            {
//                hurt = false;
//                died = false;
//                anim.SetBool("hurt", hurt);
//                anim.SetBool("died", died);
//                isImmune = false;
//            }
//        }
//    }

//    public void TakeDamage(int damage)
//    {
//        if (!isImmune)
//        {
//            health -= damage;
//            if (lives > 0 && health > 0)
//            {
//                hurt = true;
//                anim.SetBool("hurt", hurt);
//            }
//            if (health <= 0 && lives > 0)
//            {
//                StartCoroutine(DieAndRespawn());
//            }
//            else if (health <= 0 && lives <= 0)
//            {
//                GameOver();
//            }
//            Debug.Log("Player health: " + health.ToString());
//            Debug.Log("Player Lives: " + lives.ToString());
//            PlayHitReaction();
//        }
//    }

//    void PlayHitReaction()
//    {
//        isImmune = true;
//        immunityTime = 0f;
//    }

//    IEnumerator DieAndRespawn()
//    {
//        health = 6;
//        lives--;
//        anim.SetBool("hurt", false);
//        anim.SetBool("died", true);

//        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length); // Wait for the duration of the die animation

//        FindObjectOfType<LevelManager>().RespawnPlayer();
//    }

//    void GameOver()
//    {
//        Debug.Log("Gameover");
//        Destroy(gameObject); // Destroy the object when no lives left and health is zero
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthstates : MonoBehaviour
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
                hurt = false;
                died = false;
                anim.SetBool("hurt", hurt);
                this.isImmune = false;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        if (!this.isImmune)
        {
            hurt = true;
            anim.SetBool("hurt", hurt);
            this.health = this.health - damage;
            if (this.health < 0)
            {
                this.health = 0;
            }
            if (this.lives > 0 && this.health == 0)
            {
                died = true;
                anim.SetBool("died", died);
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

        anim.SetBool("died", died);
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
