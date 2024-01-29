using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManagerCutScene : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    private string[] dialogueSentence;
    private int index = 0;
    public float typingSpeed;
    public GameObject dialogueBox;
    public Image characterImage;
    public Rigidbody2D player;
    //public int cutScene;
    public int currentSceneIndex;
    public bool Ending1;

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
    
    isDialogueActive = true;
    dialogueBox.SetActive(true);

    // Setting the char image according to the name
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

        if (textDisplay.text == dialogueSentence[index])
        {
             Eskot();
            Invoke("NextSentence", 0.8f);
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
             FindObjectOfType<AudioManager>().PlayRandom("dialogue","dialoguerandom"); 
             break;
        // Default sound if the character name is not recognized
    }
}

   /* public IEnumerator TypeDialogue()
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
                Invoke("NextSentence", 0.8f);
            }
        }
    }
*/

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
            
            textDisplay.text = "";
            dialogueBox.SetActive(false);
            this.dialogueSentence = null;
            index = 0;
            player.constraints = RigidbodyConstraints2D.None;
            player.constraints = RigidbodyConstraints2D.FreezeRotation;
            isDialogueActive = false;
            if (!Ending1) {
                Invoke("load", 0.3f); 
            }
        }
    }

    public void load()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

}


