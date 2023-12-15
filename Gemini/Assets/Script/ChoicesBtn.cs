using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChoicesBtn : MonoBehaviour
{
    public GameObject chocies;
    public static bool isChoosing = false;

    void Start()
    {
        chocies.SetActive(false);
    }

    void Update()
    {
        
    }

    public void returnToEarth()
    {
        isChoosing = false;
        chocies.SetActive(false);
        SceneManager.LoadScene("ending1");    
    }

    public void stayIntheShip()
    {
        isChoosing = false;
        chocies.SetActive(false);
        SceneManager.LoadScene("ending2");
    }

    public void setChoices(bool c)
    {
        isChoosing = true;
        chocies.SetActive(c);
    }
}
