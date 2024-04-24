using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    public Collider2D hitbox;
    public StatsUpdater playerStats;
    public bool isHatted = false;

    private void Update()
    {
        if (playerStats.life <= 0)
        {
            isHatted = true;
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
            isHatted = false;
            hitbox.enabled = true;
            transform.gameObject.tag = "Player";
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = true;
            }
        }
    }
    public bool GetHatted()
    {
        return isHatted;
    }
}
