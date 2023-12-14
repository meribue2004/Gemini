using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class Sound 
{
    public string name;
   public AudioClip clip;
   [Range(0f,1f)]//make slider 
   public float volume;
   [Range(0.1f,3f)]//make slider 
   public float pitch;
   public bool loop;

[HideInInspector]
   public AudioSource source;
}