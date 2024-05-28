using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    public StatsUpdater playerStats;

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
        }
        playerStats.animator.SetBool("IsHatted", playerStats.isHatted);
    }
}
