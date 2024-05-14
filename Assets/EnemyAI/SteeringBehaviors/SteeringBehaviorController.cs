using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Steering[] steerings;

    public float maxAcceleration = 10f;
    public float maxAngularAcceleration = 3f;
    public float drag = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        steerings = GetComponents<Steering>();
        rb.drag = drag;
    }

    void FixedUpdate ()
    {
        Vector2 accelaration = Vector2.zero;
        float rotation = 0f;
        
        foreach (Steering behavior in steerings)
        {
            SteeringData steering = behavior.GetSteering(this);
            accelaration += steering.linear * behavior.GetWeight();
            rotation += steering.angular * behavior.GetWeight();
        }
            
        if (accelaration.magnitude > maxAcceleration)
        {
            accelaration.Normalize();
            accelaration *= maxAcceleration;
        }
        
        rb.AddForce(accelaration);

        if (rotation != 0)
        {
            rb.rotation = rotation;
        }
    }
}
