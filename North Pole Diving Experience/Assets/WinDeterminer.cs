using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WinDeterminer : MonoBehaviour
{
    public Canvas winCanvas;
    public PlayerInput playerInput;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(StatusControl.Instance().CanWinLevel())
            {
                winCanvas.enabled = true;
                playerInput.enabled = false;
            }
        }
    }
}
