using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public PlayerInputManager playerManager;
    public GameObject playerselectorScreen;
    public List<GameObject> players = new List<GameObject>();
    public Action<int, GameObject> onJoin;
    public int index = 0;
    public ColorSelector cs1;// cs2, cs3, cs4;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        cs1.onColorSet = SetColor;
        //cs2.onColorSet = SetColor;
        //cs3.onColorSet = SetColor;
        //cs4.onColorSet = SetColor;
    }
    void OnPlayerJoined(PlayerInput playerInput)
    {
        players.Add(playerInput.gameObject);
        playerInput.name = $"Player {index + 1}";
        DontDestroyOnLoad(playerInput.gameObject);
        onJoin.Invoke(index + 1, playerInput.gameObject);
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
}
