using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerCooldown : MonoBehaviour
{
    public GameObject bar;
    public Vector3 offset;
    public Image coolBar;

    public float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         bar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    public IEnumerator cooldown(float shootingInterval)
    {
         bar.SetActive(true);
            float currentTime = 0f;

        while (currentTime < shootingInterval)
        {
            currentTime += Time.deltaTime;
            coolBar.fillAmount = 1 - (currentTime / shootingInterval);
            yield return null;
        }

        bar.SetActive(false); // Hide the cooldown UI
        
    }
}
