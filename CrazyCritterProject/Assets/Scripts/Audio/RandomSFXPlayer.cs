using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSFXPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Vector2 pitchRange = Vector2.one;
    
    private int lastPlayedClipIndex = -1;
    
    public void PlayRandomSFX()
    {
        audioSource.pitch = Random.Range(pitchRange.x, pitchRange.y);
        int clipIndex = Random.Range(0, audioClips.Count);
        if (clipIndex == lastPlayedClipIndex)
        {
            clipIndex = (clipIndex + 1) % audioClips.Count;
        }
        audioSource.clip = audioClips[clipIndex];
        audioSource.Play();
    }

    private void Reset()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
