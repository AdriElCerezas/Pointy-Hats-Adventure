using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public PlayerInputManager playerManager;
    public GameObject playerselectorScreen;
    public List<GameObject> players = new List<GameObject>();
    public Action<int, GameObject> onJoin;
    public int index = 0;
    public ColorSelector cs1, cs2, cs3, cs4;
    public bool enableShooting;
    public bool allDead = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        cs1.onColorSet = SetColor;
        cs2.onColorSet = SetColor;
        cs3.onColorSet = SetColor;
        cs4.onColorSet = SetColor;
    }
    void OnPlayerJoined(PlayerInput playerInput)
    {
        players.Add(playerInput.gameObject);
        playerInput.name = $"Player {index + 1}";
        DontDestroyOnLoad(playerInput.gameObject);
        onJoin.Invoke(index + 1, playerInput.gameObject);
        playerInput.GetComponentInChildren<PlayerShooter>().playerManager = this;
    }
    public void EnableJoin()
    {
        gameObject.GetComponent<PlayerInputManager>().EnableJoining();
    }
    public void DisableJoin()
    {
        gameObject.GetComponent<PlayerInputManager>().DisableJoining();
    }
    void SetColor(Color c, int i)
    {
        players[i].GetComponent<SpriteRenderer>().color = c;
    }
    private void FixedUpdate()
    {
        int deadPlayers = 0;
        foreach (var p in players)
        {
            if (p.tag == "Hatted")
            {
                deadPlayers++;
            }
        }
        if (deadPlayers == index + 1)
        {
            SceneManager.LoadScene("GameRestarter");
        }
    }
}
