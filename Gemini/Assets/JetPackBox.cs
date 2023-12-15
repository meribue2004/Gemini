using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackBox : MonoBehaviour
{
    public GameObject winJetPack;
    public bool collided = false;
    // Start is called before the first frame update
    void Start()
    {
        winJetPack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            open();
        }
    }

    public void open()
    {
        Destroy(this.gameObject);
        winJetPack.SetActive(true);
        DialogueManager.isDialogueActive = true;
    }
    public void closee()
    {
        Debug.Log("Close");
        winJetPack.SetActive(false);
        DialogueManager.isDialogueActive = false;
    }
}
