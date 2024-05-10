using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclops_SM : StateMachine
{
    public override void Update()
    {
        switch (state)
        {
            case States.Idle:
                Idle(); break;
            case States.Chase:
                Chase(); break;
            case States.Die:
                Die(); break;
            default:
                Idle();
                break;
        }
        PlayerSelector();
        state = decision.Decide(state);
    }
    protected override void Chase()
    {
        direction = choosenPlayer.transform;
        enemyMovement.SetPlayerObj(direction);
    }
    void PlayerSelector()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        float closestDistance = Mathf.Infinity;

        foreach (GameObject player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                choosenPlayer = player;
            }
        }
    }
}
