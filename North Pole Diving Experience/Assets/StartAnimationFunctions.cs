using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationFunctions : MonoBehaviour
{
    public GameObject playerGameObject;
    public AudioSource splashSound;

    public void PlayerStart()
    {
        playerGameObject.SetActive(true);
        playerGameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 10);
    }

    public void PlaySplashSound()
    {
        splashSound.Play();
    }
}
