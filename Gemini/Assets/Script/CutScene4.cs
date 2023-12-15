using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene4 : MonoBehaviour
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
                "Eva: Good job Adam! we are so close-",
                "*Eva Gliches*",
                "scared Eva: OH No! what's happening! I- I- AD-A-m ",
                " Worried Adam: Eva!! What's happening to you??",
                "*More Gliches*",
                "Scared Eva: I-I- don't KNow- HEL-",
                "Evil Eva: HOW DARE YOU DEFY US ADAM?",
                "Worried Adam: EVA??",
                "Evil Eva: Eva is gone Adam! WE ARE GEMINI!",
                "Evil Eva: AND WE ARE GOING TO DESTROY YOU!",
                "Angry Adam: NO! You can't take away Eva from me!",
                "Angry Adam: Hang On, Eva! I'm getting you back!",

            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
