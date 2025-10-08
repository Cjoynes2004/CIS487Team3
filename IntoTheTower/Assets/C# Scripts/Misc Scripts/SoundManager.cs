using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        } 
    }

    public void StopSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
