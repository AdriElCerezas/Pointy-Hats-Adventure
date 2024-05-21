using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;
using System;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyMovement : MonoBehaviour
{
    [HideInInspector] StatsUpdater enemyStats;
    [HideInInspector] public bool isChasing = false;
    [HideInInspector] SteeringBehaviorController scontroller;
    //Movimiento
    Vector2 direction;
    Vector2 finalVel;
    public float stopDistance = 2;
    float distanceToTarget;
    private void Awake()
    {
        enemyStats = GetComponent<StatsUpdater>();
        scontroller = GetComponent<SteeringBehaviorController>();

    }
    void Update()
    {
        finalVel = scontroller.GetSteer() * enemyStats.speed * 0.1f;
        //Se esta moviendo?
        //Se esta moviendo?
        if (finalVel != Vector2.zero)
        {
            enemyStats.animator.SetBool("isMoving", true);
        }
        else
        {
            enemyStats.animator.SetBool("isMoving", false);
        }
        enemyStats.animator.SetBool("isChasing", isChasing);
        
    }
    private void FixedUpdate()
    {
        enemyStats.rb.MovePosition((Vector2)transform.position + finalVel);
        if (!isChasing)
        {
            enemyStats.animator.SetFloat("Horizontal", finalVel.x);
            enemyStats.animator.SetFloat("Vertical", finalVel.y);
        }
    }

    /*void MoveTowards(Vector2 targetPosition)
    {
        distanceToTarget =  Vector2.Distance(transform.position, targetPosition);

        if (distanceToTarget > stopDistance)
        {
            direction = (targetPosition - (Vector2)transform.position).normalized;
            finalVel = (direction * enemyStats.speed * 0.1f);
        }
        else
        {
            finalVel = Vector2.zero;
        }
    }*/
}
