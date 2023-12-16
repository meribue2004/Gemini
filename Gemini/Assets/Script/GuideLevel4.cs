using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideLevel4 : MonoBehaviour
{
    public DialogueManager dialogueManager;
    private bool isTriggered;
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
                "Worried Eva: Oh no! Gemini has sent a lot of robots after us!",
                "Worried Eva: They are catching up so quickly!",
                "Eva: Now, you can use your shield to protect you from any bullets. it lasts only 5 seconds.",
                "Eva: You can only use it once every 10 seconds.",
                "Eva: Fight the robots!",
                "Eva: Watch out from the blue robots, their shots are strong.",
                "Eva: Good Luck!",
            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
