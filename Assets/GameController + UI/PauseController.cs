using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    bool isPaused = false;
    PlayerManager playerManager;
    public GameObject pauseScreen;
    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }
    public void onPause()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
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
    public void OnRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameRestarter");
    }
}
