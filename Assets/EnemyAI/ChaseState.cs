
using System.Data;
using UnityEngine;

public class ChaseState : BaseState
{
    private EnemyFSM enemyFSM;

    public ChaseState(EnemyFSM stateMachine) : base("chase", stateMachine)
    {
        enemyFSM = stateMachine;
    }

    public override void Update()
    {
        base.Update();
        var enemySightSensor = stateMachine.GetComponent<EnemySightSensor>();
        var moveScript = enemyFSM.GetComponent<EnemyMovement>();

        moveScript.SetDestination(enemySightSensor.closestPlayer);

        var sightSensor = stateMachine.GetComponent<EnemySightSensor>();
        if (sightSensor.IsFarEnough())
        {
            stateMachine.ChangeState(enemyFSM.patrolState);
        }
    }
}