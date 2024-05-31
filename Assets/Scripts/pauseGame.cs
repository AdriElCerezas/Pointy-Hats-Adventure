using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class pauseGame : MonoBehaviour
{
    GameObject gameManager;
    private void Awake()
    {
        gameManager = GameObject.FindWithTag("GameController");
    }
    public void Pause(InputAction.CallbackContext ctx)
    {
        gameManager.GetComponent<PauseController>().onPause();
    }
}
