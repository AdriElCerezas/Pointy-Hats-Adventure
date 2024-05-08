using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;
using System;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyMovement : MonoBehaviour
{
    public StatsUpdater enemyStats;

    //Movimiento
    Vector2 direction;
    Vector2 finalPos;
    public float stopDistance = 2;
    Transform destination;

    private void Start()
    {
        enemyStats = GetComponent<StatsUpdater>();
    }
    void Update()
    {
        if(destination != null)
        {
            MoveTowards(destination.position);
        }
    }
    private void FixedUpdate()
    {
        enemyStats.rb.MovePosition(finalPos);
    }
    void MoveTowards(Vector2 targetPosition)
    {
        float distanceToTarget = Vector2.Distance(transform.position, targetPosition);

        if (distanceToTarget > stopDistance)
        {
            direction = (targetPosition - (Vector2)transform.position).normalized;
            finalPos = enemyStats.rb.position + (direction * enemyStats.speed * Time.deltaTime);
            enemyStats.animator.SetBool("isMoving", true);
        }
        else
        {
            enemyStats.animator.SetBool("isMoving", false);
        }
    }

    public void SetPlayerObj (Transform destination)
    {
        this.destination = destination;
    }
}
