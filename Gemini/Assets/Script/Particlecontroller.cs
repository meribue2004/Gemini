using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particlecontroller : MonoBehaviour
{
    [SerializeField] ParticleSystem Movmentparticle;
[Range(0, 10)]
    [SerializeField] int occurAfterVelocity;
    [Range(0, 0.2f)]
    [SerializeField] float dustFormationPeriod;
    [SerializeField] ParticleSystem Fallparticle;
    [SerializeField] Rigidbody2D playerRb;
    float counter;
    public Transform player;
    bool isgrounded = true;
    bool prevstate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        prevstate = isgrounded;
        isgrounded=player.GetComponent<PlayerMovement>().getgrounded();
        if(prevstate==false && isgrounded==true)
        {
            Fallparticle.Play();
        }

        counter += Time.deltaTime;
        if (isgrounded && Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity) {
            if (counter > dustFormationPeriod){

                Movmentparticle.Play();
                counter = 0;

            }
        }
    }
}

