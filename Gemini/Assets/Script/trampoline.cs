
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class trampoline : MonoBehaviour
//{
//    private Animator anim;

//    public float jumpForce = 190f;
//    // Start is called before the first frame update
//    void Start()
//    {
//        anim = GetComponent<Animator>();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//    void OnTriggerEnter2D(Collider2D other)
//    {

//        if (other.gameObject.CompareTag("Player"))
//        {

//            StartCoroutine(jumpp());
//            // Check if the colliding object has a Rigidbody2D
//            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
//            if (rb != null)
//            {
//                rb.gravityScale = 0.6f;
//                rb.mass = 1.0f;
//                // Apply upward force to launch the player
//                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
//                resetgravity();
//                rb.gravityScale = 0.9f;
//                rb.mass = 5.0f;
//            }
//        }
//    }
//    IEnumerator jumpp()
//    {
//        anim.SetTrigger("jumping");
//        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
//        anim.SetTrigger("def");
//    }
//    IEnumerator resetgravity()
//    {

//        yield return new WaitForSeconds(5f);
//    }
//}


using System.Collections;
using UnityEngine;

public class trampoline : MonoBehaviour
{
    private Animator anim;
    public float jumpForce = 190f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(JumpSequence(other.GetComponent<Rigidbody2D>()));
        }
    }

    IEnumerator JumpSequence(Rigidbody2D rb)
    {
        anim.SetTrigger("jumping");

        // Apply upward force to launch the player
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        rb.gravityScale = 0.4f;
        rb.mass = 0.8f;

        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Reset gravity and mass
        rb.gravityScale = 0.9f;
        rb.mass = 5.0f;

        // Wait for the animation duration
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        anim.SetTrigger("def");
    }
}

