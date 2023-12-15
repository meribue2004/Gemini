using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene5a : MonoBehaviour
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
                "Adam: NO you are Lunatic! I will free those people from you and we will live in peace and harmony on planet Earth. ",
                " Evil Eva: So you're killing the only one who helped you Adam? Huh, just what I expected.. ",
                " Sad Adam: I am so sorry Eva. I will find a way to rebuild you! I promise! But For now I have to do this to save the humanity.",
                " *Adam kills Evangeline *",
                "Adam: *sighs..* let's do this. For Grandpa Lu and Eva!",
                "*Adam steers the ship back successfuly to planet Earth*",
                "Adam: Ah, at last here we are! Back to Earth. it is beautiful just like how Grandpa Lu described it.",
                "Adam: *sighs* I miss you Eva...What have I done?",
                "*noises of people arguing*",
                "Adam: No , really what have I done???",
                "Adam: With no Gemini, how can I lead all those people?...",
                "THE END",
                "CONGRATULATIONS! you finished the game! you chose to save the humanity but you scarifieced Eva.. That's okay tough desicions are always taken.",
                "You can play again and try a different ending!",
            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
