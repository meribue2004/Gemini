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
using UnityEngine.UI; //for health bar ui
using TMPro;

using UnityEngine.SceneManagement;

public class Healthstates : MonoBehaviour
{
      public GameObject eva;
    public int health = 6;

    public int lives = 3;

    private SpriteRenderer spriteRenderer;

    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;

    private Animator anim;
    private bool hurt;
    private bool died = false;

    public Image healthBar; 
    public Image[] heartImages;
    bool canmove;
    public int coinsCollected = 0;
    public float timecollected = 0;
    public float heartscollected = 0;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        //spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
         healthBar.fillAmount = 0.771f;
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
                canmove = true;
                FindObjectOfType<PlayerMovement>().setcanmove(canmove);
                this.isImmune = false;
            }
        }
    }
   public void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().Play("hurt");
        

        if (!this.isImmune)
        {
            if(damage==1){
                healthBar.fillAmount -= 0.1285f;
            }
            if(damage==2){
                healthBar.fillAmount -= 0.257f;
            }
            if(damage==3){
                healthBar.fillAmount -= 0.3855f;
            }
            canmove = false;
            FindObjectOfType<PlayerMovement>().setcanmove(canmove);
            hurt = true;
            anim.SetBool("hurt", hurt);
            this.health = this.health - damage;
          

           
            if (this.health < 0)
            {
                this.health = 0;
            }
            if (this.lives > 1 && this.health == 0)
            {
                //died = true;
                StartCoroutine(DieAndRespawn());
                ResetHealth();
              
                this.lives--;
                Color imageColor = heartImages[lives].color;
                        imageColor.a = 0f; // Set alpha to 0 (fully transparent)
                        heartImages[lives].color = imageColor;
            }
            else if (this.health == 0 && this.lives == 1)
            {
                

  
                SceneManager.LoadScene("DieMenu");
                
                this.lives--;
                Color imageColor = heartImages[lives].color;
                imageColor.a = 0f; // Set alpha to 0 (fully transparent)
                heartImages[lives].color = imageColor;
                Debug.Log("Gameover");
                Destroy(eva);
                Destroy(this.gameObject); // Destroy the object when no lives left and health is zero
                
            }
            Debug.Log("Player health:" + this.health.ToString());
            Debug.Log("Player Lives:" + this.lives.ToString());

            PlayHitReaction();
        }
    }
    //koki reset health 
  public  void ResetHealth()
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
        this.lives--;
        Color imageColor = heartImages[lives].color;
                        imageColor.a = 0f; // Set alpha to 0 (fully transparent)
                        heartImages[lives].color = imageColor;
        
        WaitAndContinue();
        if (this.lives > 1)
        {
            StartCoroutine(DieAndRespawn());
            
            
        }

        else if ( this.lives < 1)
        {
            GameOver();// Destroy the object when no lives left and health is zero
            Destroy(this.gameObject);
        }

        Debug.Log("Player health:" + this.health.ToString());
        Debug.Log("Player Lives:" + this.lives.ToString());

        PlayHitReaction();
    }
    //koki timer 
     public void DecreaselivesTimer()
    { 
         this.lives--;
        // Ensure that lives - 1 is a valid index for the heartImages array
Color imageColor = heartImages[lives ].color;
imageColor.a = 0f; // Set alpha to 0 (fully transparent)
heartImages[lives ].color = imageColor;
       
        if ( this.lives >=1)
        {
            died = true;
                anim.SetBool("died", died);
                 WaitAndContinue();
                FindObjectOfType<LevelManager>().RespawnPlayer();
                ResetHealth();
              
             
                

        }

        else if (this.lives <1)
        {
            GameOver(); // Destroy the object when no lives left and health is zero
             Destroy(this.gameObject);
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

    public void CollectCoin()
    {
        coinsCollected++;
        Debug.Log(coinsCollected);
        scoreText.text = coinsCollected.ToString();
    }
    public void inctime()
    {
        Debug.Log("hereee");

        timecollected += 30;
        Debug.Log(timecollected);
        FindObjectOfType<Timer>().currentTime += 30f;


    }
    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    //if (col.gameObject.tag == "Score")
    //    //{
    //    //    coinsCollected++;
    //    //    Debug.Log(coinsCollected);

    //    //    scoreText.text = coinsCollected.ToString();
    //    //}
    //    if (col.gameObject.tag == "Heart")
    //    {
    //        //ResetHealth();
    //        Debug.Log(heartscollected);
    //    }
    //    if(col.gameObject.tag=="Time")
    //    {
    //       FindObjectOfType<Timer>().currentTime+=30;
    //        Debug.Log(timecollected);
    //    }
    //}
    IEnumerator DieAndRespawn()
    {
        health = 6;
      
 
        //died = true;
       
        anim.SetTrigger("playanimation");
        Debug.Log("in respawn:");
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length); // Wait for the duration of the die animation

        FindObjectOfType<LevelManager>().RespawnPlayer();
        anim.SetTrigger("stopdinganimation");
    }

    void GameOver()
    {
        Debug.Log("Gameover");
        Destroy(gameObject); // Destroy the object when no lives left and health is zero
    }
}
