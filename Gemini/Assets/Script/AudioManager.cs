using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource pauseMenu;
    public AudioSource mainMenu;
    public AudioSource loseMenu;
    public AudioSource winMenu;
    public AudioSource intenseGameplayMusic;
    public AudioSource normalGameplayMusic;
    public AudioSource winEfx;
    public AudioSource dieEfx;
    public AudioSource footstepsEfx;
    public AudioSource playerweapon1Efx;
    public AudioSource playerweapon2Efx;
    public AudioSource enemyweaponEfx;
    public AudioSource keyCollectEfx;
    public AudioSource healthkitEfx;
    public AudioSource timekitEfx;
    //public AudioSource dieEfx;
    public AudioSource ambient;
    public AudioSource dialoguemememew;
    public AudioSource dialogueSara;
    public AudioSource cutscene;

    public static AudioManager instance = null; // allow other scripts to call functions from AudioManager
    
    // Start is called before the first frame update
    void Start()
    {
        // Your Start logic goes here
    }

    void Awake()
    {
        // Check if there is already an instance of AudioManager
        if (instance == null)
        {
            // If not, set it to this
            instance = this;
        }
        else if (instance != this)
        {
            // If another instance already exists, destroy this one
            Destroy(gameObject);
        }

        // Make AudioManager persist across scenes
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Your Update logic goes here
    }
    public void PlaySingle(AudioClip clip){
     
    }
}
