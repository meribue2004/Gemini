using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingDialog : MonoBehaviour
{
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            string[] dialogue =
            {
                "Adam: blah blah blah",
                "Scared Eva: oh no really",
                "Worried Eva: More blah blah blah",
                "Eva: me memme meem mem",
                "Adam: human noices",
                "Evil Eva: robot noices"
            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
