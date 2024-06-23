using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyFSM : StateMachine
{
    [HideInInspector]
    public PatrolState patrolState;
    [HideInInspector]
    public ChaseState chaseState;

    private void Awake()
    {
        Init();
        
        patrolState = new PatrolState(this);
        chaseState = new ChaseState(this);
    }

    protected override BaseState GetInitialState()
    {
        return patrolState;
    }
}