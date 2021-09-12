using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnDisable : MonoBehaviour
{
    public AudioSource audioSource;
    public float minPitch = 1f;
    public float maxPitch = 2f;

    private void OnDisable()
    {
        print("Break!!");

        if(audioSource != null)
        {
            audioSource.pitch = Random.Range(minPitch,maxPitch);
            audioSource.Play();
        }
    }
}
