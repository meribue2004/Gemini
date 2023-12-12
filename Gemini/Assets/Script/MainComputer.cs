using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainComputer : EnemyController
{

    public float shootingInterval = 5f;
    private float timeSinceLastShot = 0f;
    void Start()
    {
       
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootingInterval)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }

        HalfHealth();
    }

    void HalfHealth()
    {
        if ((MaxHitPoint / 2) == HitPoints)
            anim.SetBool("halfHealth", true);
     
}
}
