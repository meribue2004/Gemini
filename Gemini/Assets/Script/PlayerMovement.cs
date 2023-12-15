using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    bool canmove=true;
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
    public KeyCode ShootKey;
    public KeyCode Shottswitch;
    public Transform firepoint;
    public GameObject bullet;
    public GameObject bulletsw;
    private Animator anim;
    public bool lev4and5;
    public float shootingInterval = 2f;
    //private float timeSinceLastShot = 2f;
    public float shootingIntervalsw = 3f;
    //private float timeSinceLastShotsw = 3f;
    bool canShoot=true;
    bool canShootsw = true;
    private bool shielded;
    public GameObject shield;
    private float shieldCooldown = 5f;
    private float lastShieldActivationTime = 0f;
    private 
    void Start()
    {
        //FindObjectOfType<AudioManager>().Play("moog");
        isFacingRight = true;
        anim = GetComponent<Animator>();
        anim.SetBool("levelgun", lev4and5);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has a specific tag 
        if (collision.gameObject.CompareTag("slant"))
        {
            // Set the boolean variable to true when the player touches the object
            playerTouchedObject = true;
            Debug.Log("Player touched the object!");
            anim.SetBool("sliding", playerTouchedObject);
        }
    }
    public void setcanmove(bool I)
    {
        canmove = I;

    }
    public void OnCollisionExit2D(Collision2D collision)
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
    void stopshoot()
    {
        anim.SetTrigger("stopshoot");
    }
    void movmentcode()
    {
        
        if (!PauseMenu.isPaused && !DialogueManager.isDialogueActive && !ChoicesBtn.isChoosing)
        {
            CheckShield();
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
                rolling = true;
            }

            if (Input.GetKeyUp(arrowdown))
            {
                rolling = false;
            }

            //if (Input.GetKeyDown(ShootKey))
            //{
            //        if (timeSinceLastShot >= shootingInterval)
            //        {

            //            Invoke("Shoot", 0.5f);
            //            anim.SetTrigger("shootwhiles");

            //            Invoke("stopshoot", 0.7f);
            //            timeSinceLastShot = 0f;
            //        }
            //    }
            if (Input.GetKeyDown(ShootKey) && canShoot)
            {
                anim.SetTrigger("shootwhiles");
                Invoke("Shoot", 0.9f);

                Invoke("stopshoot", 0.9f);
                StartCoroutine(ResetShootingInterval());
            }
            if (Input.GetKeyDown(Shottswitch) && canShootsw)
            {
                anim.SetTrigger("shootwhiles");


                Invoke("Shootswitchside", 0.9f);
                Invoke("stopshoot", 0.9f);
                StartCoroutine(ResetShootingIntervalsw());
            }
            anim.SetBool("rolling", rolling);

            anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        }
    }
    void Update()
    {
        if (canmove)
        {
            movmentcode();
        }
        //timeSinceLastShot += Time.deltaTime;
        //timeSinceLastShotsw += Time.deltaTime;

      
    }

    public void flip()
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

    public bool getgrounded()
    {
        return grounded;
    }
    public void Shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }
    public void Shootswitchside()
    {
        Instantiate(bulletsw, firepoint.position, firepoint.rotation);
    }
    IEnumerator ResetShootingInterval()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootingInterval);
        canShoot = true;
    }
    IEnumerator ResetShootingIntervalsw()
    {
        canShootsw = false;
        yield return new WaitForSeconds(shootingInterval);
        canShootsw = true;
    }

    void CheckShield()
    {
        if (Input.GetKey(KeyCode.S) && Time.time >= lastShieldActivationTime + 10f && !shielded)
        {
            StartCoroutine(ActivateShield());
        }
    }

    IEnumerator ActivateShield()
    {
        // Activate shield
        shield.SetActive(true);
        shielded = true;

        // Update the last shield activation time
        lastShieldActivationTime = Time.time;

        // Wait for the cooldown duration
        yield return new WaitForSeconds(shieldCooldown);

        // Deactivate shield after the cooldown
        shield.SetActive(false);
        shielded = false;
    }
}