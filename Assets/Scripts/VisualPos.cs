using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualPos : MonoBehaviour
{
    Transform tr;
    float exponent = 0.0001f;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y*exponent);
    }
}
