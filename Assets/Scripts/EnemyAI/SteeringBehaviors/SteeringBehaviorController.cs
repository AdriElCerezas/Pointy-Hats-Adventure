using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Steering[] steerings;
    private EnemyMovement enemyMovement;

    public float maxAcceleration = 3f;
    public float maxAngularAcceleration = 2f;
    public float drag = 1f;
    Vector2 steer = Vector2.zero;
    public Transform target; 

    // Start is called before the first frame update
    void Start()
    {
        target = transform;
        rb = GetComponent<Rigidbody2D>();
        steerings = GetComponents<Steering>();
        rb.drag = drag;
    }

    void FixedUpdate ()
    {
        Vector2 finalDir = Vector2.zero;
        
        foreach (Steering behavior in steerings)
        {
            SteeringData steering = behavior.GetSteering(this);
            finalDir += steering.linear * behavior.GetWeight();
        }
            
        if (finalDir.magnitude > maxAcceleration)
        {
            finalDir.Normalize();
            finalDir *= maxAcceleration;
        }
        steer = finalDir.normalized; 
    }
    public Vector2 GetSteer()
    {
        return steer;
    }
    public void SetDestination(Transform destination)
    {
        target = destination;
    }
}
