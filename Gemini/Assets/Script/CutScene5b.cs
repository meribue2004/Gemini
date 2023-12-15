using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene5b : MonoBehaviour
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
                "Adam: *sighs* If I agreed to what you're saying, how can I gurantee the safety of my people and Eva?",
                "Evil Eva: Don't worry Adam,I was designed to put everything under control. Eva will be free from me and you and your people will continue living on this spaceship. ",
                "Evil Eva: I will forgive you and everything will go back to exactly the way it was.",
                "Adam: how am I supposed to go back to how it was? after knowing the truth?",
                "Evil Eva: let me handle it Adam. I will get rid of all those thoughts that tormented you and you will be happy just like everyone else.",
                "Adam:....",
                "Adam: Fine, do it!",
                "Eva: You made the right desicion, Adam.",
                "*Gemini wipes Adam's memory*",
                "Adam: Huh, what happened? I feel so dizzy..maybe I should get back to my room.",
                "*Adam sees Grandpa Lu and robots in the hallway...*",
                "Granpa Lu: Let me go! They deserve to know the truth!!!",
                "Adam: huh, who is this man? why are they dragging him like this?",
                "Adam: I wonder what happened to the poor old man.. he looks like he's out of his mind..",
                "Adam: That emblem looks so familiar....where have I seen it before..?",
                "*Eva Approaches Adam*",
                "Eva: He is someone who claims to be a former scientist...Crazy rihgt?? ",
                "Adam: Yeah...who are you?",
                " Happy Eva: Hi, I'm Eva! your personal robot assistant and a friend!",
                "THE END!",
                "CONGRATULATIONS! you finished the game! you chose to save Eva but Humans won't return to earth forever.. That's okay tough desicions are always taken.",
                "You can play again and try a different ending!",
            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
