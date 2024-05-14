using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehavior : Steering
{
    [SerializeField]
    private float wanderRate = 0.4f;
    [SerializeField]
    private float wanderOffset = 1.5f;
    [SerializeField]
    private float wanderRadius = 4f;
    
    private float wanderOrientation = 0f;

    private float RandomBinomial()
    {
        return Random.value - Random.value;
    }
    
    private Vector2 OrientationToVector(float orientation)
    {
        return new Vector2(Mathf.Cos(orientation), Mathf.Sin(orientation));
    }

    public override SteeringData GetSteering(SteeringBehaviorController steeringController)
    {
        wanderOrientation += RandomBinomial() * wanderRate;

        float characterOrientation = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        float targetOrientation = wanderOrientation + characterOrientation;
        
        Vector2 targetPosition = (Vector2)transform.position + (wanderOffset * OrientationToVector(characterOrientation));
        targetPosition += wanderRadius * OrientationToVector(targetOrientation);

        return new SteeringData()
        {
            linear = (targetPosition - (Vector2)transform.position).normalized * steeringController.maxAcceleration,
            angular = 0f
        };
    }
}
