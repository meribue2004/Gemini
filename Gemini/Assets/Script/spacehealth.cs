
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for health bar ui
public class spacehealth : MonoBehaviour
{


    float zValue = 15;
    private float startTime;
    private SpriteRenderer spriteRenderer;
    public float shakeDuration = 1.5f;
    public float shakeIntensity = 1f;

    private Vector3 startPosition;

    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;

    private bool canMove = true;
    private Vector3 originalPosition;
   


  


    void Start()
    {
        //spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
      
        originalPosition = transform.position;
  

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
                FindObjectOfType<spaceship_movment>().SetCanMove(canMove);

                this.isImmune = false;
            }
        }
    }
    public void TakeDamage()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (!this.isImmune)
        {

            canMove = false;
            FindObjectOfType<spaceship_movment>().SetCanMove(canMove);
            // betermmy leh wara 3shan may3odesh yetkhebet fy el obs

        
            StartCoroutine(ShakePlayer());
       
          

            PlayHitReaction();
        }
    }


    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
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



}
