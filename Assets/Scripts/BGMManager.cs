using System;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioSource audioSource;
    private int currentSong = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.PlayOneShot(clips[currentSong]);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }
    
    private void PlayNextSong()
    {
        audioSource.PlayOneShot(clips[currentSong+=1]);
        if(currentSong > clips.Length - 1) currentSong = 0; 
    }

}
