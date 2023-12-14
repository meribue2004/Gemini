using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D boxCollider;

    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    public void OpenDoor()
    {
        StartCoroutine(Open());
    }

    IEnumerator Open()
    {
        anim.SetBool("Open", true);
        
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        boxCollider.enabled = false;
        anim.SetBool("StayOpen", true);

    }

    public void LockDoor()
    {
        StartCoroutine(Lock());
    }

    IEnumerator Lock()
    {
        anim.SetBool("StayOpen", false);
        anim.SetBool("Open", false);
        anim.SetBool("Close", true);

        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        boxCollider.enabled = true;
        anim.SetBool("StayClosed", true);


    }
}
