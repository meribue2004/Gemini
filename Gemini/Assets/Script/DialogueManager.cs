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
    public Image bg;
    public Sprite Adam;
    public Sprite Eva;
    public Sprite EvaScareed;
    public Sprite EvaWorried;
    public Sprite EvaEvil;
    public Dictionary<string, Sprite> characterImages;

    void Start()
    {
        characterImages = new Dictionary<string, Sprite>();
        characterImages.Add("Adam", Adam);
        characterImages.Add("Eva", Eva);
        characterImages.Add("Scared Eva", EvaScareed);
        characterImages.Add("Worried Eva", EvaWorried);
        characterImages.Add("Evil Eva", EvaEvil);
        dialogueBox.SetActive(false);
        continueButton.SetActive(false);
        SetPanelAlpha(0f);
    }
    void Update()
    {
        
    }

    public IEnumerator TypeDialogue()
    {
        dialogueBox.SetActive(true);
        SetPanelAlpha(0.3f);
        player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

        // Extract character name from the dialogue sentence
        string characterName = dialogueSentence[index].Split(':')[0].Trim();
        // Change the character image based on the character name
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
            continueButton.SetActive(true);
        }
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
            this.dialogueSentence=null;
            index = 0;
            player.constraints = RigidbodyConstraints2D.None;
            player.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void SetPanelAlpha(float alpha)
    {
        Color panelColor = bg.color;
        panelColor.a = alpha;
        bg.color = panelColor;
    }
}
