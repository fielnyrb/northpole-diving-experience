using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationFunctions : MonoBehaviour
{
    public AudioSource[] pickaxeSounds;

    public void pickaxeSoundPlay()
    {
        int playIndex = Random.Range(0,pickaxeSounds.Length);
        pickaxeSounds[playIndex].Play();
    }
}
