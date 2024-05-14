
using System.Data;
using UnityEngine;

public class PatrolState : BaseState
{
    private EnemyFSM enemyFSM;

    public PatrolState(EnemyFSM stateMachine) : base("patrol", stateMachine)
    {
        enemyFSM = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        var moveScript = enemyFSM.GetComponent<EnemyMovement>();

        moveScript.SetDestination(enemyFSM.transform);
    }

    public override void Update()
    {
        base.Update();
        var moveScript = enemyFSM.GetComponent<EnemyMovement>();
        //Idle movement
        //To Do
        moveScript.SetDestination(enemyFSM.transform);

        //chase?
        var sightSensor = stateMachine.GetComponent<EnemySightSensor>();
        if (sightSensor.IsCloseEnough())
        {
            stateMachine.ChangeState(enemyFSM.chaseState);
        }
    }
}