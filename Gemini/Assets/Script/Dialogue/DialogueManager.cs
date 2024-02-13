using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    private string[] dialogueSentence;
    private int index = 0;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject dialogueBox;
    public Image characterImage;
    public Rigidbody2D player;

    public Sprite Adam;
    public Sprite Eva;
    public Sprite EvaScareed;
    public Sprite EvaWorried;
    public Sprite EvaEvil;
    public Sprite Lu;
    public Dictionary<string, Sprite> characterImages;

    public static bool isDialogueActive;
    private bool skip = false;

    void Start()
    {
        isDialogueActive = false;
        characterImages = new Dictionary<string, Sprite>();
        characterImages.Add("Adam", Adam);
        characterImages.Add("Eva", Eva);
        characterImages.Add("Scared Eva", EvaScareed);
        characterImages.Add("Worried Eva", EvaWorried);
        characterImages.Add("Evil Eva", EvaEvil);
        characterImages.Add("Lu", Lu);
        dialogueBox.SetActive(false);
        continueButton.SetActive(false);
    }

    public IEnumerator TypeDialogue()
    {
        
            isDialogueActive = true;

        dialogueBox.SetActive(true);

        //setting the char image according to the name
        string characterName = dialogueSentence[index].Split(':')[0].Trim();
        if (characterImages.ContainsKey(characterName))
        {
            Sprite characterSprite = characterImages[characterName];
            characterImage.sprite = characterSprite;

            // Adjust the size of the Image component based on the sprite size
            characterImage.rectTransform.sizeDelta = new Vector2(characterSprite.rect.width, characterSprite.rect.height);
        }

        GetSoundForCharacter(characterName);

        
            foreach (char letter in dialogueSentence[index].ToCharArray())
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(typingSpeed);

                if (!skip)
                {
                    if (textDisplay.text == dialogueSentence[index])
                    {
                        Eskot();
                        continueButton.SetActive(true);
                    }
                }
            }
        

    }
  private void Eskot(){
    FindObjectOfType<AudioManager>().Stop("dialogue");
            FindObjectOfType<AudioManager>().Stop("dialogue1");
            FindObjectOfType<AudioManager>().Stop("dialogue2");
            FindObjectOfType<AudioManager>().Stop("dialoguerandom");
}
private void GetSoundForCharacter(string characterName)
{
    // You can use a switch statement or other logic to map character names to sound names
    switch (characterName)
    {
        case "Lu":
           FindObjectOfType<AudioManager>().Play("dialogue1");
           break; // Adjust this to the actual sound name you want to play for "meme" character.
        case "Adam":
             FindObjectOfType<AudioManager>().Play("dialogue2");
             break;
        // Add more cases as needed for different characters
        case "Eva":
             FindObjectOfType<AudioManager>().Play("dialogue"); 
             break;
        case "Worried Eva":
             FindObjectOfType<AudioManager>().Play("dialogue"); 
             break;
        case "Scared Eva":
             FindObjectOfType<AudioManager>().Play("dialogue"); 
             break;
        case "Evil Eva":
             FindObjectOfType<AudioManager>().Play("dialogue"); 
             break;
        // Default sound if the character name is not recognized
    }
}

    public void SetSentences(string[] sentences)
    {
        this.dialogueSentence = sentences;
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < dialogueSentence.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(TypeDialogue());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            dialogueBox.SetActive(false);
            this.dialogueSentence = null;
            index = 0;
            player.constraints = RigidbodyConstraints2D.None;
            player.constraints = RigidbodyConstraints2D.FreezeRotation;
            isDialogueActive = false;
        }
    }

    public void Skip()
    {
        skip = true;
        Eskot();
        index = dialogueSentence.Length - 1;
        NextSentence();
    }

}

