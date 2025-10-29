using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource; //Sound Effect source, more should be added - TO DO
    
    //Load up more sound effects - TO DO
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //Play Sound, will add parameter to play specific effect when we have more
    public void PlaySound()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        } 
    }

    //Stop sound, same as above comment
    public void StopSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
