using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene3 : MonoBehaviour
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
                "Eva: This is it; we just need to reach the room containing the chip..",
                "Eva: It's up there! But we must deactivate the gravity to reach there.",
                "Eva: hmmmmm...... ",
                "*Worried Eva: I see some drones up there! I’m betting more are about to come.",
                "Worried Eva: we need to find a way to defend ourselves!",
                "Adam:Huh, I once fixed my toaster by giving it a stern look..I can handle this!",

            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
