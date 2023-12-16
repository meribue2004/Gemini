using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideLevel2 : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public bool isTriggered;
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
        if (collision.tag == "Player" && !isTriggered)
        {
            isTriggered = true;
            string[] dialogue =
            {
                "Worried Eva: Becareful, Adam. ",
                "Worried Eva: Gemini has a lot of traps along the way. ",
                "Worried Eva: Avoid Obsticales as much as you can.",
                "Eva: Good Luck!",
            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
