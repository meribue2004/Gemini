using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene4 : MonoBehaviour
{
    public DialogueManagerCutScene dialogueManager;
    public bool isTriggered;
    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player" && !isTriggered)
        {
            isTriggered = true;
            string[] dialogue =
            {
                "Scared Eva: OH No! what's happening! I- I- AD-A-m ",
                "Adam: Eva!! What's happening to you??",
                "Scared Eva: I-I- don't KNow- HEL-",
                "Evil Eva: HOW DARE YOU DEFY US ADAM?",
                "Adam: EVA??",
                "Evil Eva: Eva is gone Adam! WE ARE GEMINI!",
                "Evil Eva: AND WE ARE GOING TO DESTROY YOU!",
                "Adam: NO! You can't take away Eva from me!",
                "Adam: Hang On, Eva! I'm getting you back!",

            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
