using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene2 : MonoBehaviour
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
                "Eva: Phew! that was close! ",
                "Adam: Now, where is the control room?",
                "Eva: The control room should be at the end of this hall. Once we get there, I will connect the wires to deactivate your tracking bracelet. ",
                "*Siren Triggeres*",
                "Worried Eva: Oh no! They spotted us! Quick we need to hurry!",
                "Adam: Then what are we waiting for? let's go!",
                
            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}