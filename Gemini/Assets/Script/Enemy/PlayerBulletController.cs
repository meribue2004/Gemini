using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    public float speed;
    private PlayerMovement player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();

        //Set the direction of the bullet to be the same direction as the player is facing
        //localScale.x value is positive if the object is facing right and negative if it's facing left.
        if (player.transform.localScale.x < 0)
        {
            speed = -speed; //if player is facing left speed in negative to move in the left direction
            transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);//fliping the bullet to the left
        }
    }

    void Update()
    {
        //setting speed:- x positivilty or negitavatly, while y unchanges since it moves only horizontally <-->
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }
}
