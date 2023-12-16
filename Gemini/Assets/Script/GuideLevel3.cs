using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideLevel3 : MonoBehaviour
{
    public DialogueManager dialogueManager;
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
                "Eva: Gemini's control chip is at the end of this tunnel. ",
                "Eva: But we must deactivate the gravity to get up there. ",
                "Eva: Good thing you just earned a jetpack now.",
                "Eva: Your shield will also come in handy, but not at the moment.",
                "Eva: Collect the gun pieces to put together a weapon.",
                "Eva: One more thing, Follow the spotlights.",
                "Eva: Good Luck!",
            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
