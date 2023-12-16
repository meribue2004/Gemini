using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for health bar ui
public class Healthsytemlevel3 : MonoBehaviour
{
  
    public int health = 6;
    public int lives = 3;
    float zValue=15;
    private float startTime;
    private SpriteRenderer spriteRenderer;
    public float shakeDuration = 1.5f;
    public float shakeIntensity = 9.7f;

    private Vector3 startPosition;

    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;

    private bool canMove = true;
    private Vector3 originalPosition;
    private Animator anim;
    private bool hurt;
  
    public float backwardThrowForce = 3f;
    public Image healthBar; 
    public Image[] heartImages;
    public float heartscollected = 0;

    void Start()
    {
        //spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        originalPosition = transform.position;
        healthBar.fillAmount = 0.771f;
      
    }

    void Update()
    {
        originalPosition = transform.position;
        if (this.isImmune == true)
        {
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                canMove = true;
                FindObjectOfType<jetpackmovment>().setcanmove(canMove);

                this.isImmune = false;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().Play("hurt");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (!this.isImmune)
        {

            canMove = false;
            FindObjectOfType<jetpackmovment>().setcanmove(canMove);
            // betermmy leh wara 3shan may3odesh yetkhebet fy el obs
        
            rb.velocity = new Vector2(-backwardThrowForce, rb.velocity.y);
            StartCoroutine(ShakePlayer());
            transform.rotation = Quaternion.Euler(0f, 0f, zValue);

            hurt = true;
           
            this.health = this.health - damage;
             healthBar.fillAmount -= 0.1285f;
            if (this.health < 0)
            {
                this.health = 0;
            }
            if (this.lives > 1 && this.health == 0)
            {
                
                WaitAndContinue();
                IncreaseGravityScale();
                WaitAndContinue();
                FindObjectOfType<LevelManagerlevel3>().RespawnPlayer();
                Invoke("ResetGravity", 3);


                ResetHealth();
                this.health = 6;
                this.lives--;
                Color imageColor = heartImages[lives].color;
                        imageColor.a = 0f; // Set alpha to 0 (fully transparent)
                        heartImages[lives].color = imageColor;
            }
            else if (this.health == 0 && this.lives == 1)
            {
                this.lives--;
                Color imageColor = heartImages[lives].color;
                imageColor.a = 0f; // Set alpha to 0 (fully transparent)
                heartImages[lives - 1].color = imageColor;
                Debug.Log("Gameover");
                Destroy(this.gameObject); // Destroy the object when no lives left and health is zero
            }
            Debug.Log("Player health:" + this.health.ToString());
            Debug.Log("Player Lives:" + this.lives.ToString());

            PlayHitReaction();
        }
    }
    void ResetGravity()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        
    }
    void ResetHealth()
    {
        health = 6;
       healthBar.fillAmount = 0.771f ;
    }

    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }
    public void Decreaselives()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        this.lives--;

      
        WaitAndContinue();
        if (this.health > 0 || this.lives > 0)
        {
            WaitAndContinue();
            IncreaseGravityScale();
           
            FindObjectOfType<LevelManagerlevel3>().RespawnPlayer();
          Invoke("ResetGravity",3);
            
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
        yield return new WaitForSeconds(5f);
        
    }

    private IEnumerator ShakePlayer()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {

            float offsetX = Mathf.Sin(Time.time * 45f) * shakeIntensity;
            transform.position = originalPosition + new Vector3(offsetX, 0f, 0f);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
        canMove = true;  // Re-enable movement after shaking
    }

    void IncreaseGravityScale()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // Increase the gravity scale by 2
        rb.gravityScale += 1.0f; 
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Heart")
        {
            ResetHealth();
            Debug.Log(heartscollected);
            Color imageColor = heartImages[lives-1].color;
            Debug.Log(imageColor);
            imageColor.a = 1f; 
            heartImages[lives-1].color = imageColor;
        }
    }
}


