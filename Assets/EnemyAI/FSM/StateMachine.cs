using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;
public enum States
{
    Idle,
    Chase,
    Die
}
public class StateMachine : MonoBehaviour
{
    protected StatsUpdater enemy;
    public States state;
    [HideInInspector] protected EnemyMovement enemyMovement;
    [HideInInspector] public DecisionMaker decision;

    public GameObject choosenPlayer;
    public Transform direction;

    public virtual void Awake()
    {
        StatsUpdater enemy = GetComponent<StatsUpdater>();
        enemyMovement = GetComponent<EnemyMovement>();
        decision = GetComponent<DecisionMaker>();
    }
    public virtual void Update()
    {
        switch (state)
        {
            case States.Idle:
                Idle();
                break;
            default:
                Idle();
                break;
        }
    }

    protected virtual void Idle()
    {
        enemyMovement.SetPlayerObj(transform);
    }
    protected virtual void Chase() { }
    protected virtual void Die() { }

}
