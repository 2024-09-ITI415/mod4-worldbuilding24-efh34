using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;  // The AudioSource component to play the music
    [SerializeField] private AudioClip background;     // The audio clip for the background music

    private void Start()
    {
        if (musicSource != null && background != null)
        {
            musicSource.clip = background;  // Set the audio clip to the background music
            musicSource.loop = true;         // Set the music to loop
            musicSource.Play();              // Start playing the background music
        }
        else
        {
            Debug.LogWarning("MusicSource or Background Clip is not assigned.");
        }
    }
}
