using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentBehavior : Steering
{
    [SerializeField]
    private float alignDistance = 8f;

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
        steering.linear = Vector3.zero;
        int count = 0;
        
        foreach (Transform target in targets)
        {
            Vector2 targetDir = target.position - transform.position;
            if (targetDir.magnitude < alignDistance)
            {
                steering.linear += target.GetComponent<Rigidbody2D>().velocity;
                count++;
            }
        }

        if (count > 0)
        {
            steering.linear /= count;
            if (steering.linear.magnitude > steeringController.maxAcceleration)
            {
                steering.linear = steering.linear.normalized * steeringController.maxAcceleration;
            }
        }
        
        return steering;
    }
}
