using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOpenDoor : MonoBehaviour
{
    private bool hasPlayed;
    public Sprite leverpulled;
    private SpriteRenderer spriteRenderer;
    private LockedDoor Door;

    void Start()
    {
        hasPlayed = false;
        spriteRenderer =  GetComponent<SpriteRenderer>();
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
            spriteRenderer.sprite = leverpulled;
            Door.OpenDoor();
        }
    }


}
