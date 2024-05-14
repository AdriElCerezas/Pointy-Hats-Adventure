using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceForwardBehavior : Steering
{
    public override SteeringData GetSteering(SteeringBehaviorController steeringController)
    {
        var rb = GetComponent<Rigidbody2D>();

        if (rb.velocity.sqrMagnitude <= float.Epsilon)
            return new SteeringData();

        var angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg + 270f;

        return new SteeringData()
        {
            linear = Vector2.zero,
            angular = angle
        };
    }
}
