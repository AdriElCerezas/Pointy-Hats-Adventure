using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueBehavior : Steering
{
    [SerializeField]
    private float maxPrediction = 2f;

    public GameObject targetObj;

    public override SteeringData GetSteering(SteeringBehaviorController steeringController)
    {
        Vector2 direction = targetObj.transform.position - transform.position;
        float distance = direction.magnitude;
        float speed = GetComponent<Rigidbody2D>().velocity.magnitude;

        float prediction;
        if (speed <= distance / maxPrediction)
            prediction = maxPrediction;
        else
            prediction = distance / speed;
            
        Vector2 predictedTarget = (Vector2)targetObj.transform.position
                + targetObj.GetComponent<Rigidbody2D>().velocity * prediction;

        return new SteeringData()
        {
            linear = (predictedTarget - (Vector2)transform.position).normalized * steeringController.maxAcceleration,
            angular = 0
        };
    }
}
