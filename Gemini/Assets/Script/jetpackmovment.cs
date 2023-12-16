using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class jetpackmovment : MonoBehaviour
{
    public float jetpackForce = 10f;
    public float moveSpeed = 5f;
    public float stoppingForce = 10f;  // Additional force for gradual stopping
    private Rigidbody2D rigdbody;
    private bool isFacingRight;

    public KeyCode arrowUp;
    public KeyCode arrowDown;
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public float rotationSpeed = 90f;
    public int gunpieces;
    float zValue;
    bool canmove = true;

    public TextMeshProUGUI gunpiecesText;
    void Start()
    {
        isFacingRight = true;
    }
   public void gunpiecescollcted()
    {
        gunpieces++;
        Debug.Log("gun peices" + gunpieces);
        gunpiecesText.text = gunpieces.ToString();
    }
    private void Awake()
    {
        rigdbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canmove && !DialogueManager.isDialogueActive) 
        {
            movmentcode();
        }
    }
    public void setcanmove(bool I) { 
        canmove = I;
    
    }
    void movmentcode()
    {
        if (Input.GetKeyDown(arrowUp)){
FindObjectOfType<AudioManager>().PlayRandom("jetpack","jetpack2");
        }
        if (Input.GetKey(arrowUp))
        {
            
            ApplyJetpackForce();
            zValue = 9 * Mathf.Sin(rotationSpeed * Time.time);

            // Set the object's rotation
            transform.rotation = Quaternion.Euler(0f, 0f, zValue);
        }
        else
        {
            // Gradually decrease jetpack force when arrowUp is released
            rigdbody.AddForce(Vector2.down * stoppingForce);
        }

        if (Input.GetKey(arrowDown))
        {
            ApplyDownwardForce();
            zValue = -9 * Mathf.Sin(rotationSpeed * Time.time);
            transform.rotation = Quaternion.Euler(0f, 0f, zValue);
        }
        else
        {
            // Gradually decrease downward force when arrowDown is released
            rigdbody.AddForce(Vector2.up * stoppingForce);
        }

        if (Input.GetKey(moveLeft))
        {
            MoveLeft();
        }
        else if (Input.GetKey(moveRight))
        {
            MoveRight();
        }
        else
        {
            rigdbody.AddForce(Vector2.right * rigdbody.velocity.x * -stoppingForce);
        }
    }

    void FixedUpdate()
    {
        //ApplyStoppingForce();
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

    void MoveLeft()
    {
        // Move left
        rigdbody.velocity = new Vector2(-moveSpeed, rigdbody.velocity.y);
        FlipIfNeeded(false);
    }

    void MoveRight()
    {
        // Move right
        rigdbody.velocity = new Vector2(moveSpeed, rigdbody.velocity.y);
        FlipIfNeeded(true);
    }

    //void ApplyStoppingForce()
    //{
    //    // Apply additional force for gradual stopping
    //    if (!Input.GetKey(moveLeft) && !Input.GetKey(moveRight))
    //    {
    //        rigdbody.AddForce(Vector2.right * rigdbody.velocity.x * -stoppingForce);
    //    }
    //}
    void FlipIfNeeded(bool faceRight)
    {
        if (isFacingRight != faceRight)
        {
            Flip();
            isFacingRight = faceRight;
        }
    }

    void Flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}

