using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueEnding1 : MonoBehaviour
{
    public DialogueManager dialogueManager;
    private bool DialogueIsTriggered;
    // Start is called before the first frame update
    void Start()
    {
        DialogueIsTriggered = false;
    }
    IEnumerator MyCoroutine()
    {
        Debug.Log("Coroutine started");
        
        // Wait for 3 seconds
        yield return new WaitForSeconds(3.0f);

       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !DialogueIsTriggered)
        {
            DialogueIsTriggered = true;
            StartCoroutine(MyCoroutine());
            string[] dialogue =
            {
                "Adam: *sighs* ...let's do this. For Grandpa Lu and Eva!",
                "Adam: blah blah blah"
            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
