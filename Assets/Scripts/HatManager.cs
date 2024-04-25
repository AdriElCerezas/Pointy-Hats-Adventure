using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    public Collider2D hitbox;
    public StatsUpdater playerStats;

    private void Update()
    {
        if (playerStats.life <= 0)
        {
            playerStats.isHatted = true;
            hitbox.enabled = false;
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
            hitbox.enabled = true;
            transform.gameObject.tag = "Player";
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = true;
            }
        }
    }
}
