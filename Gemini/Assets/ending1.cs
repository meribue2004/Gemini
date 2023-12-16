using System.Collections;
using UnityEngine;

public class ending1 : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public bool DialogueIsTriggered;
    public Canvas canvas;

    void Start()
    {
        DialogueIsTriggered = false;
    }

    IEnumerator MyCoroutine()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(6.0f);

        // Hide the canvas after the delay
        canvas.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !DialogueIsTriggered)
        {
            DialogueIsTriggered = true;

            // Start the coroutine for the delay
            StartCoroutine(MyCoroutine());

            // Set up your dialogue
            string[] dialogue =
            {
                "Adam: NO you are Lunatic! I will free those people from you and we will live in peace and harmony on planet Earth."
            };

            // Start typing the dialogue
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
