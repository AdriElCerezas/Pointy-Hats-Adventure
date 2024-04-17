using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFreeze : MonoBehaviour
{
    public bool freezeCamera;
    public Collider2D cameraWall;
    public Collider2D cameraTrigger;
    int count = 0;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        freezeCamera = true;
        count++;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        count--;
        if (count <= 1)
        {
            freezeCamera = false;
        }
    }
    public bool IsFrozen()
    {
        return freezeCamera;
    }
}
