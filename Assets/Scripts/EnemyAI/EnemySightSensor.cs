using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightSensor : MonoBehaviour
{
    public Transform closestPlayer;
    public float sightDistance = 5.0f;
    float lostDistance = 10.0f;
    GameObject[] players;
    private void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        closestPlayer = PlayerSelector(players)?.GetComponent<Transform>();
        lostDistance = sightDistance * 2;
    }

    private float GetPlayerDistance()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        closestPlayer = PlayerSelector(players)?.GetComponent<Transform>();
        if (closestPlayer == null)
            return float.MaxValue;
        return Vector2.Distance(closestPlayer.position, transform.position);
    }

    public bool IsCloseEnough()
    {
        return GetPlayerDistance() <= sightDistance;
    }

    public bool IsFarEnough()
    {
        return GetPlayerDistance() > lostDistance;
    }

    GameObject PlayerSelector(GameObject[] players)
    {
        GameObject closestPlayer = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayer = player;
            }
        }

        return closestPlayer;
    }
}
