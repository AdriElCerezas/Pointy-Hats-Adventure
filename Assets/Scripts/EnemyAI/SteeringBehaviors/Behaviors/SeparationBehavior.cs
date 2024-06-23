using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparationBehavior : Steering
{
    [SerializeField]
    private float threshold = 2f;
    [SerializeField]
    private float decayCoefficient = -25f;

    private Transform[] targets;

    void Start()
    {
        SteeringBehaviorController[] agents = FindObjectsOfType<SteeringBehaviorController>();
        targets = new Transform[agents.Length - 1];
        int count = 0;
        
        foreach (SteeringBehaviorController agent in agents)
        {
            if (agent.gameObject != gameObject)
            {
                targets[count++] = agent.transform;
            }
        }
    }

    public override SteeringData GetSteering(SteeringBehaviorController steeringController)
    {
        SteeringData steering = new SteeringData();
        
        foreach (Transform target in targets)
        {
            Vector2 direction = target.transform.position - transform.position;
            float distance = direction.magnitude;
            
            if (distance < threshold)
            {
                float strength = Mathf.Min(decayCoefficient / (distance *  distance), steeringController.maxAcceleration);
                direction.Normalize();
                steering.linear += strength * direction;
            }
        }
        
        return steering;
    }
}
