using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider bar;
    public Color low;
    public Color High;
    public Vector3 offset;//the height of the enemy

    // Update is called once per frame
    void Update()
    {
        bar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position+offset); //placing the bar above the enemy at all time
    }

    public void SetHealth(float currentHealth, float maxHealth)
    {

        //value
        bar.value = currentHealth;
        bar.maxValue = maxHealth;


        //colors
        bar.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, High, bar.normalizedValue);
    }
}
