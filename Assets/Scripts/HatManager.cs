using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    public StatsUpdater playerStats;
    bool nowDead = false;
    PlayerManager playerManager;

    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("GameController").GetComponentInChildren<PlayerManager>();
    }
    private void Update()
    {
        if (playerStats.Life <= 0)
        {
            playerStats.isHatted = true;
            transform.gameObject.tag = "Hatted";
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = false;
            }
            GetComponent<Renderer>().enabled = true;
            if (!nowDead)
            {
                nowDead = true;
                playerManager.DeadPlayer();

            }
        }
        else
        {
            playerStats.isHatted = false;
            transform.gameObject.tag = "Player";
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = true;
            }
            GetComponent<Renderer>().enabled = true;
            if (nowDead)
            {
                nowDead = false;
                playerManager.RevivedPLayer();
            }
        }
        playerStats.animator.SetBool("IsHatted", playerStats.isHatted);
    }
}
