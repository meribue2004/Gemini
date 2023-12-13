using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public Transform laser;
    public Sprite leverpulled;
    private bool hasPlayed;
    public bool leverl3=true;
    private LockedDoor Door;

    void Start()
    {
        hasPlayed = false;
        Door = FindObjectOfType<LockedDoor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Player" && !hasPlayed)
        {
            hasPlayed = true;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = leverpulled;

            if (leverl3) 
            { 
                laser.GetComponent<leverturned>().leverturnedd();
                
                Transform objectTransform = transform;
                objectTransform.position = new Vector3(objectTransform.position.x, 7, objectTransform.position.z);
            }
            else
            {
                Door.OpenDoor();
            }

            
            
        }
    }
}
