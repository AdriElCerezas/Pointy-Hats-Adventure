using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceBehavior : Steering
{
    public Transform target;

    public override SteeringData GetSteering(SteeringBehaviorController steeringController)
    {
        Vector2 direction = target.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270f;

        return new SteeringData()
        {
            linear = Vector2.zero,
            angular = Mathf.LerpAngle(transform.rotation.eulerAngles.z,
                    angle, steeringController.maxAngularAcceleration * Time.deltaTime)
        };
    }
}
