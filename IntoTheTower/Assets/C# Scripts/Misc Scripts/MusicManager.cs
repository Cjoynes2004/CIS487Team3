using System.IO;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource; //Background music, to be made by Chandler :) - TO DO
  
    //Play music when level starts
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusic();
    }

    //Method to play music
    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    //Method to stop music
    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
