using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricshock : MonoBehaviour
{
  
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2D;
    public float shakeDuration = 0.5f; 
    public float shakeIntensity = 0.1f;

    private Vector3 startPosition;
    private float shakeTimer;
    public float flickerDuration = 1.0f;  
    public float flickerInterval = 0.7f;   

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        startPosition = transform.position;
         FindObjectOfType<AudioManager>().Play("lvl3");
        StartCoroutine(FlickerSprite());
    }
    void Update()
    {
        Vector2 shakeOffset = Random.insideUnitCircle * shakeIntensity;
        transform.position = startPosition + new Vector3(shakeOffset.x, shakeOffset.y, 0f);
    }

    private IEnumerator FlickerSprite()
    {
        while (true)
        {
           

        
            spriteRenderer.enabled = !spriteRenderer.enabled;

            
            collider2D.enabled = !collider2D.enabled;

          
            yield return new WaitForSeconds(flickerInterval);

           
            spriteRenderer.enabled = true;
            collider2D.enabled = true;

            yield return new WaitForSeconds(flickerDuration - flickerInterval);
        }
    }
    public int damage = 1;
    void OnTriggerEnter2D(Collider2D collider)
    {


        if (collider.tag == "Player")
        {
             FindObjectOfType<AudioManager>().Play("electrify");
            
            FindObjectOfType<Healthsytemlevel3>().TakeDamage(damage);
            //FindObjectOfType<LevelManager>().RespawnPlayer();
        }
    }
}

