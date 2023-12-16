using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene5b : MonoBehaviour
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
                "Adam: Huh, what happened? I feel so dizzy..maybe I should get back to my room.",
                "Lu: Let me go! They deserve to know the truth!!!",
                "Adam: huh, who is this man? why are they dragging him like this?",
                "Adam: I wonder what happened to the poor old man.. he looks like he's out of his mind..",
                "Adam: That emblem looks so familiar....where have I seen it before..?",
                "Eva: He is someone who claims to be a former scientist...Crazy rihgt?? ",
                "Adam: Yeah...who are you?",
                "Eva: Hi, I'm Eva! your personal robot assistant and a friend!"
            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
