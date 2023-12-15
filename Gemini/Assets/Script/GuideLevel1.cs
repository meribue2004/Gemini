using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideLevel1 : MonoBehaviour
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
                "Eva: Avoid camera survieliance by going in the opposite direction. this way Gemini won't catch you.",
                "Eva: Collect keys along the way to unlock the control room.",
                "Eva: Yikes! avoid the spikes.",
                "Eva: Good Luck!",
            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
