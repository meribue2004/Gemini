using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; //list of sounds with certain properties
    public Sound[] levelSoundtracks;
    



    // public static AudioManager instance = null; // allow other scripts to call functions from AudioManager

    

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
        // if (instance == null)
        // {
        //     // If not, set it to this
        //     instance = this;
        // }
        // else if (instance != this)
        // {
        //     // If another instance already exists, destroy this one
        //     Destroy(gameObject);
        // }

        // // Make AudioManager persist across scenes
        // DontDestroyOnLoad(gameObject);
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
     public void PlayRandom(string soundName1, string soundName2)
    {
        // Choose a random index (0 or 1) to determine which sound to play
        int randomIndex = UnityEngine.Random.Range(0, 2);

        // Get the corresponding sound clip based on the random index
        string selectedSoundName = (randomIndex == 0) ? soundName1 : soundName2;

        // Find the sound with the selected name
        Sound s = Array.Find(sounds, sound => sound.name == selectedSoundName);

        // If the sound is found, play it
        if (s != null)
        {
            s.source.Play();
        }
        else
        {
            Debug.LogWarning("One or both sound names not found.");
        }
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound with name " + name + " not found.");
            return;
        }

        s.source.Stop();
    }
    // public void Stop(string name)
    // {
    //     Sound s = Array.Find(sounds, sound => sound.name == name);

    //     if (s == null)
    //     {
    //         Debug.LogWarning("Sound with name " + name + " not found.");
    //         return;
    //     }

    //     s.source.Stop();
    // }
    
    // public void PlaySingle(AudioClip clip){
    //  efxSource.clip=clip;
    //  efxSourse.Play();
    // }
}
