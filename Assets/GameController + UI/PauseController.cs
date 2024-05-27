using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    bool isPaused = false;
    PlayerManager playerManager;
    public GameObject pauseScreen;
    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(isPaused);
            Time.timeScale = 1;
        }
        else
        {
            isPaused = true;
            pauseScreen.SetActive(isPaused);
            Time.timeScale = 0;
        }
        playerManager.enableShooting = !isPaused;
    }
}
