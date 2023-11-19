using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adammovmentplatform : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public bool isFacingRight;
    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode arrowdown;
    public KeyCode R;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private bool rolling;
    public bool playerTouchedObject = false;
    private Animator anim;

   
    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has a specific tag (e.g., "YourObjectTag")
        if (collision.gameObject.CompareTag("slant"))
        {
            // Set the boolean variable to true when the player touches the object
            playerTouchedObject = true;
            Debug.Log("Player touched the object!");
            anim.SetBool("sliding", playerTouchedObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Reset the boolean variable when the player leaves the object
        if (collision.gameObject.CompareTag("slant"))
        {
            playerTouchedObject = false;
            Debug.Log("Player left the object!");
            anim.SetBool("sliding", playerTouchedObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }
        anim.SetBool("grounded", grounded);
        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (isFacingRight)
            {
                flip();
                isFacingRight = false;
            }
        }
        if (Input.GetKey(R))

        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (!isFacingRight)
            {
                flip();
                isFacingRight = true;
            }
        }
        if (Input.GetKeyDown(arrowdown))
        {

            rolling= true;  
        }
        if (Input.GetKeyUp(arrowdown)){
            rolling = false;
        }
      
        anim.SetBool("rolling", rolling);

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));



    }
   
    void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

    }
}