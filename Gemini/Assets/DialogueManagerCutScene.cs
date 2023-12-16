using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManagerCutScene : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    private string[] dialogueSentence;
    private int index = 0;
    public float typingSpeed;
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
    }

    public IEnumerator TypeDialogue()
    {
         
        FindObjectOfType<AudioManager>().Play("meme");
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

        foreach (char letter in dialogueSentence[index].ToCharArray())
        {
            textDisplay.text += letter;

            yield return new WaitForSeconds(typingSpeed);

            if (textDisplay.text == dialogueSentence[index])
            {
                Invoke("NextSentence", 0.5f);
            }
        }
    }


    public void SetSentences(string[] sentences)
    {
        this.dialogueSentence = sentences;
    }

    public void NextSentence()
    {
        if (index < dialogueSentence.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(TypeDialogue());
        }
        else
        {
            FindObjectOfType<AudioManager>().Stop("meme");
            textDisplay.text = "";
            dialogueBox.SetActive(false);
            this.dialogueSentence = null;
            index = 0;
            player.constraints = RigidbodyConstraints2D.None;
            player.constraints = RigidbodyConstraints2D.FreezeRotation;
            isDialogueActive = false;
        }
    }

}


