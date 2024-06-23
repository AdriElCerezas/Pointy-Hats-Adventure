using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoidanceBehavior : Steering
{
    [SerializeField]
    private float radius;

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
                targets[count++] = agent?.transform;
            }
        }
    }

    public override SteeringData GetSteering(SteeringBehaviorController steeringController)
    {
        SteeringData steering = new SteeringData();
        float shortestTime = float.PositiveInfinity;
        Transform firstTarget = null;
        float firstMinSeparation = 0, firstDistance = 0, firstRadius = 0;
        Vector2 firstRelativePos = Vector2.zero, firstRelativeVel = Vector2.zero;

        foreach (Transform target in targets)
        {
            Vector2 relativePos = transform.position - target.position;
            Vector2 relativeVel = GetComponent<Rigidbody2D>().velocity - target.GetComponent<Rigidbody2D>().velocity;
            float distance = relativePos.magnitude;
            float relativeSpeed = relativeVel.magnitude;

            if (relativeSpeed == 0)
                continue;

            float timeToCollision = -1 * Vector2.Dot(relativePos, relativeVel) / (relativeSpeed * relativeSpeed);

            Vector2 separation = relativePos + relativeVel * timeToCollision;
            float minSeparation = separation.magnitude;

            if (minSeparation > radius + radius)
                continue;

            if ((timeToCollision > 0) && (timeToCollision < shortestTime))
            {
                shortestTime = timeToCollision;
                firstTarget = target;
                firstMinSeparation = minSeparation;
                firstDistance = distance;
                firstRelativePos = relativePos;
                firstRelativeVel = relativeVel;
                firstRadius = radius;
            }
        }

        if (firstTarget == null)
            return steering;

        if (firstMinSeparation <= 0 || firstDistance < radius + firstRadius)
            steering.linear = transform.position - firstTarget.position;
        else
            steering.linear = firstRelativePos + firstRelativeVel * shortestTime;
 
        steering.linear.Normalize();
        steering.linear *= steeringController.maxAcceleration;

        return steering;
    }
}
