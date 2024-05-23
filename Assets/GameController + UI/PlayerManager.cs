using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public PlayerInputManager playerManager;
    public GameObject playerselectorScreen;
    public List<GameObject> Players = new List<GameObject>();
    public Action<int> onJoin;
    public int index = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void OnPlayerJoined(PlayerInput playerInput)
    {
        Players.Add(playerInput.gameObject);
        playerInput.name = $"Player {index + 1}";
        DontDestroyOnLoad(playerInput.gameObject);
        onJoin.Invoke(index);
    }
    public void EnableJoin()
    {
        gameObject.GetComponent<PlayerInputManager>().EnableJoining();
    }
    public void DisableJoin()
    {
        gameObject.GetComponent<PlayerInputManager>().DisableJoining();
    }
}
