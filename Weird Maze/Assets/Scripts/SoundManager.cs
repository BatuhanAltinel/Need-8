using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    AudioSource audioSource; 
    public AudioClip dustAudio;
    public AudioClip speedAudio;

    private void Awake()
    {
        if (soundManager == null)
            soundManager = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void DustAudio()
    {
        audioSource.PlayOneShot(dustAudio);
    }
    public void SpeedAudio()
    {
        audioSource.PlayOneShot(speedAudio);
    }
    
}
