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
    Vector2 finalVel;
    public float stopDistance = 2;
    public Transform destination;
    float distanceToTarget;
    [HideInInspector]public bool isChasing = false;

    void Update()
    {
        // Si se encontró un jugador cercano, mover al enemigo hacia su posición
        if (destination != null && destination != transform)
        {
            MoveTowards(destination.position);
            isChasing = true;
        } else
        {
            finalVel = Vector2.zero;
            isChasing = false;
        }
        if (finalVel != Vector2.zero)
        {
            enemyStats.animator.SetBool("isMoving", true);
        }
        else
        {
            enemyStats.animator.SetBool("isMoving", false);
        }
    }
    private void FixedUpdate()
    {
        enemyStats.rb.MovePosition((Vector2)transform.position + finalVel);
    }

    public void SetDestination(Transform destination)
    {
        this.destination = destination;
    }

    void MoveTowards(Vector2 targetPosition)
    {
        distanceToTarget =  Vector2.Distance(transform.position, targetPosition);

        if (distanceToTarget > stopDistance)
        {
            direction = (targetPosition - (Vector2)transform.position).normalized;
            finalVel = (direction * enemyStats.speed * Time.deltaTime);
        }
        else
        {
            finalVel = Vector2.zero;
        }
    }
}
