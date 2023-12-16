using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene5a : MonoBehaviour
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
                "Adam: NO you are a Lunatic! I will free those people from you and we will live in peace and harmony on planet Earth. ",
                " Evil Eva: So you're killing the only one who helped you Adam? Huh, just what I expected.. ",
                "Adam: I am so sorry Eva. I will find a way to rebuild you! I promise! But For now I have to do this to save the humanity.",
            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
