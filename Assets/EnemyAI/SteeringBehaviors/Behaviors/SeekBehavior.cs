using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehavior : Steering
{
    public Transform target;

    public override SteeringData GetSteering(SteeringBehaviorController steeringController)
    {
        if (target == null)
            return new SteeringData();

        return new SteeringData()
        {
            linear = (target.position - transform.position).normalized * steeringController.maxAcceleration,
            angular = 0.0f
        };
    }
    public void SetDestination(Transform destination)
    {
        target = destination;
    }
}
