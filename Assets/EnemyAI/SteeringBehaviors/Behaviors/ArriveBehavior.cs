using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveBehavior : Steering
{
    [SerializeField]
    private float targetRadius = 1.5f;
    [SerializeField]
    private float slowRadius = 5f;

    public Transform target;

    public override SteeringData GetSteering(SteeringBehaviorController steeringController)
    {
        SteeringData steering = new SteeringData();
        Vector2 direction = target.position - transform.position;
        float distance = direction.magnitude;
        
        if (distance < targetRadius)
        {
            steeringController.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return steering;
        }

        float targetSpeed;
        if (distance > slowRadius)
            targetSpeed = steeringController.maxAcceleration;
        else
            targetSpeed = steeringController.maxAcceleration *  (distance / slowRadius);
        
        Vector2 targetVelocity = direction.normalized * targetSpeed;
        steering.linear = targetVelocity - steeringController.GetComponent<Rigidbody2D>().velocity;
        
        if (steering.linear.magnitude > steeringController.maxAcceleration)
        {
            steering.linear.Normalize();
            steering.linear *= steeringController.maxAcceleration;
        }
        
        return steering;
    }

}
