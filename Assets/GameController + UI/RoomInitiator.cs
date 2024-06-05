using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class RoomInitiator : MonoBehaviour
{
    public Action<bool> onDoorsClose;
    public Action<bool> onSpawn;
    int playersInside = 0;
    static int totalPlayers;
    bool roomClosed = false;
    List<GameObject> enemyInside = new List<GameObject>();
    private void Start()
    {
        totalPlayers = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerManager>().players.Count;
        onDoorsClose.Invoke(roomClosed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        {
            if (collision.tag == "Player" || collision.tag == "Hatted")
            {
                playersInside++;
                if (playersInside == totalPlayers && roomClosed == false)
                {
                    roomClosed = true;
                    onSpawn.Invoke(roomClosed);
                    onDoorsClose.Invoke(roomClosed);
                }
            }
            if (collision.tag == "Enemy")
            {
                enemyInside.Add(collision.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        {
            if (collision.tag == "Player" || collision.tag == "Hatted")
            {
                playersInside--;
            }
            if (collision.tag == "Enemy" && roomClosed == true)
            {
                enemyInside.Remove(collision.gameObject);
                if (enemyInside.Count == 0)
                {
                    roomClosed = false;
                    onDoorsClose.Invoke(roomClosed);
                    Destroy(this);
                }
            }
        }
    }
}