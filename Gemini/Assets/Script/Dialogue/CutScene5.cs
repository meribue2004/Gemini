using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene5 : MonoBehaviour
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
                "Evil Eva:YOU MERE HUMAN! You have no idea what you are doing!! ",
                "Evil Eva: I AM the one who kept order in this spaceship! I AM the one who is protecting planet earth!!  ",
                " Angry Adam: Protecting them?? you are trapping them in your spaceship when they should be leading better lives back at their own home planet!",
                "Evil Eva: YOU THINK I DON'T KNOW BETTER??? I'm protecting your beloved earth from Humans like you! it's YOU who destroyed earth with your nuclear wars killing millions of people!!",
                "Evil Eva: IAM GEMINI! and I Was programmed to maintain sustainbi- sustainability on planet earth! without me YOU can not survive! You will destroy planet Earth Again and again!",
                " Angry Adam: HOW DO YOU KNOW THAT?? ",
                "Evil Eva: I have already seen it before. I can predict what's going to happen..",
                "Evil Eva: I can also predict your next move, Adam..",
                "Evil Eva: Which is why i'm giving you 2 choices: ",
                "Evil Eva: You can either walk away, forget this ever happened and we will all live together with peace and harmony inside the spaceship.",
                "Evil Eva: OR , you can Kill ME and EVA, go back to your so called Earth but bear your consequences on your own!",
                "Evil Eva: Choose, Adam! Humanity or Eva?",

            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }


}
