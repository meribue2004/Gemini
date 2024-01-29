using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene1 : MonoBehaviour
{
    public DialogueManagerCutScene dialogueManager;
    public bool isTriggered;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("ambience");
        FindObjectOfType<AudioManager>().Play("bg");
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
               
                "Lu: As you already know Adam, Earth hasn't healed yet..but that is not the truth!!",
                "Adam: Whoa, what do you mean?",
                "Lu: 40 years ago,me and my scientist collegues have discovered the earth has finally healed and we can go back to planet Earth, but Gemini wasn't too happy about it..",
                "Lu: Gemini wanted to stay in control of the ship and humans, and so it decided to keep that information to itself by wiping away the memory of my collegues.",
                "Lu: Luckily, I managed to evade it at the last minute.",
                "Adam: We won't let that happen again, Grandpa. We will tell them the truth this time and send those people back to their homeland. ",
                "Lu: But it won't be easy, Adam. You must disable Gemini's control of the ship by taking the control chip and turning it manual.",
                "Lu: but first, you need to deactivate your tracking bracelet.",
                "Adam: How can I do it?",
                "Eva: Don't worry Adam, I can handle it and i will help you through your mission.",
                "Adam: Then let's get going, Eva.",
                 
            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
