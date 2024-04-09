using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualPos : MonoBehaviour
{
    // Start is called before the first frame update
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
