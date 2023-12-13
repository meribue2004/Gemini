using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; //list of sounds with certain properties
    // public AudioSource pauseMenu;
    // public AudioSource mainMenu;
    // public AudioSource loseMenu;
    // public AudioSource winMenu;
    // public AudioSource intenseGameplayMusic;
    // public AudioSource normalGameplayMusic;
    // public AudioSource winEfx;
    // public AudioSource dieEfx;
    // public AudioSource footstepsEfx;
    // public AudioSource playerweapon1Efx;
    // public AudioSource playerweapon2Efx;
    // public AudioSource enemyweaponEfx;
    // public AudioSource keyCollectEfx;
    // public AudioSource healthkitEfx;
    // public AudioSource timekitEfx;
    // //public AudioSource dieEfx;
    // public AudioSource ambient;
    // public AudioSource dialoguemememew;
    // public AudioSource dialogueSara;
    // public AudioSource cutscene;



    public static AudioManager instance = null; // allow other scripts to call functions from AudioManager

    

    void Awake()//loop through list and for each sound add an audio
    {
       
        foreach(Sound s in sounds){
            s.source=gameObject.AddComponent<AudioSource>(); //set the current sound audiosoruce to the audio source of the current gameobject
             s.source.clip=s.clip;//assign thaudio clip
             s.source.volume=s.volume;
             s.source.pitch=s.pitch;
             s.source.loop=s.loop;
        }
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

    // play sounds
   void Start()
    {
        // Your Start logic goes here
    }
    public void Play(string name){
        //loop through all sounds and find the sound with the appropriate name
        Sound s = Array.Find(sounds, sound => sound.name == name);

        //if dont find audio name
        if(s==null){
            return;//nth happens
        }
        
        s.source.Play();
    }
    // public void PlaySingle(AudioClip clip){
    //  efxSource.clip=clip;
    //  efxSourse.Play();
    // }
}
