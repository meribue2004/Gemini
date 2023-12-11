using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public GameObject bar;
    public Vector3 offset;
    public Image HealthBar;

    // Update is called once per frame
    void Update()
    {
        bar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset); //placing the bar above the enemy at all time
    }

    public void setHealth(float currenthealth, float maxHealth)
    {
        HealthBar.fillAmount = currenthealth / maxHealth;
    }
}
