using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class winBoxController : MonoBehaviour
{
    public GameObject WinBox;

    // Start is called before the first frame update
    void Start()
    {
        WinBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void open()
    {

        Debug.Log("open");
        DialogueManager.isDialogueActive = true;
        WinBox.SetActive(true);
    }

    public void Tolevel4()
    {
        Debug.Log("close");
        DialogueManager.isDialogueActive = false;
        SceneManager.LoadScene("Level 4");
        //WinBox.SetActive(false);
    }

    public void Tolevel3()
    {
        Debug.Log("close");
        DialogueManager.isDialogueActive = false;
        SceneManager.LoadScene("Level 3");
    }

}
