
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class spaceship_movment : MonoBehaviour
//{
//    public float jetpackForce = 10f;
//    public float moveSpeed = 5f;
//    public float stoppingForce = 10f;
//    public float smoothDamping = 0.1f; // Added damping for smoother movement
//    private Rigidbody2D rigdbody;


//    public KeyCode arrowUp;
//    public KeyCode arrowDown;
//    public KeyCode moveLeft;
//    public KeyCode moveRight;
//    float zValue;
//    bool canMove = true;
//    private int facingDirection = 1; // 1 for right, -1 for left

//    void Start()
//    {
//        rigdbody = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        if (canMove)
//        {
//            MovementCode();
//        }
//    }

//    public void SetCanMove(bool canMove)
//    {
//        this.canMove = canMove;
//    }

//    void MovementCode()
//    {
//        if (Input.GetKey(arrowUp))
//        {
//            ApplyJetpackForce();
//        }
//        else if (Input.GetKey(arrowDown))
//        {
//            ApplyDownwardForce();
//        }


//        else if (Input.GetKey(moveRight))
//        {

//            MoveRight();

//        }
//        else
//        {
//            ApplyStoppingForce();
//        }

//        // Smooth rotation even when not applying force
//        zValue = Mathf.Lerp(zValue, 0f, Time.deltaTime * smoothDamping);
//    }

//    void FixedUpdate()
//    {
//        // Damping for smoother movement
//        rigdbody.velocity = new Vector2(
//            Mathf.Lerp(rigdbody.velocity.x, 0f, Time.deltaTime / smoothDamping),
//            rigdbody.velocity.y
//        );
//    }

//    void ApplyJetpackForce()
//    {
//        // Apply upward force for the jetpack
//        rigdbody.AddForce(Vector2.up * jetpackForce);
//    }

//    void ApplyDownwardForce()
//    {
//        // Apply downward force
//        rigdbody.AddForce(Vector2.down * jetpackForce);
//    }



//    void MoveRight()
//    {
//        // Move right
//        rigdbody.velocity = new Vector2(moveSpeed, rigdbody.velocity.y);

//    }

//    void ApplyStoppingForce()
//    {
//        // Apply additional force for gradual stopping using Lerp
//        rigdbody.velocity = new Vector2(
//            Mathf.Lerp(rigdbody.velocity.x, 0f, Time.deltaTime * smoothDamping),
//            rigdbody.velocity.y
//        );
//    }


//}
using System.Collections;
using UnityEngine;

public class spaceship_movment : MonoBehaviour
{
    public float jetpackForce = 10f;
    public float moveSpeed = 5f;
    public float stoppingForce = 10f;
    public float smoothDamping = 0.1f; // Added damping for smoother movement
    private Rigidbody2D rigdbody;

    public KeyCode arrowUp;
    public KeyCode arrowDown;
    public KeyCode moveRight;
    float zValue;
    bool canMove = true;
    private int facingDirection = 1; // 1 for right, -1 for left

    public float maxY = 29.4f;
    public float minY = -64f;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("earthbg");
        rigdbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            MovementCode();
        }
    }

    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }

    void MovementCode()
    {
        if (Input.GetKey(arrowUp))
        {
            ApplyJetpackForce();
        }
        else if (Input.GetKey(arrowDown))
        {
            ApplyDownwardForce();
        }
        else if (Input.GetKey(moveRight))
        {
            MoveRight();
        }
        else
        {
            ApplyStoppingForce();
        }

        // Smooth rotation even when not applying force
        zValue = Mathf.Lerp(zValue, 0f, Time.deltaTime * smoothDamping);

        // Clamp the y-position to stay within the desired range
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
    }

    void FixedUpdate()
    {
        // Damping for smoother movement
        rigdbody.velocity = new Vector2(
            Mathf.Lerp(rigdbody.velocity.x, 0f, Time.deltaTime * smoothDamping),
            rigdbody.velocity.y
        );
    }

    void ApplyJetpackForce()
    {
        // Apply upward force for the jetpack
        rigdbody.AddForce(Vector2.up * jetpackForce);
    }

    void ApplyDownwardForce()
    {
        // Apply downward force
        rigdbody.AddForce(Vector2.down * jetpackForce);
    }

    void MoveRight()
    {
        // Move right
        rigdbody.velocity = new Vector2(moveSpeed, rigdbody.velocity.y);
    }

    void ApplyStoppingForce()
    {
        // Apply additional force for gradual stopping using Lerp
        rigdbody.velocity = new Vector2(
            Mathf.Lerp(rigdbody.velocity.x, 0f, Time.deltaTime * smoothDamping),
            rigdbody.velocity.y
        );
    }
}

