using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBox : MonoBehaviour
{
    public GameObject winObject;
    public bool collided = false;
    // Start is called before the first frame update
    void Start()
    {
        winObject.SetActive(false);
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
        winObject.SetActive(true);
        DialogueManager.isDialogueActive = true;
    }
    public void closee()
    {
        Debug.Log("Close");
        winObject.SetActive(false);
        DialogueManager.isDialogueActive = false;
    }
}
