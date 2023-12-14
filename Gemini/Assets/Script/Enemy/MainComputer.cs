using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainComputer : EnemyController
{

    public Sprite HalfHealth;
    public Sprite Death;
    private SpriteRenderer sr;
    public float shootingInterval = 5f;
    private float timeSinceLastShot = 0f;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootingInterval)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }

        Health();
    }

    void Health()
    {
        if ((MaxHitPoint / 2) == HitPoints)
        {
            Debug.Log("half health");
            sr.sprite = HalfHealth;
        }
        if (HitPoints == 0)
        {
            sr.sprite = Death;
        }
    }
}
