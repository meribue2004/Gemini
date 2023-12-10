using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public Transform laser;
    public Sprite leverpulled;
    private bool hasPlayed;
    // Start is called before the first frame update

    void Start()
    {
        hasPlayed = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Player" && !hasPlayed)
        {
           
            laser.GetComponent<leverturned>().leverturnedd();
                hasPlayed = true;

            Transform objectTransform = transform;

         
            objectTransform.position = new Vector3(objectTransform.position.x,7 , objectTransform.position.z);
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = leverpulled;
            
        }
    }
}
