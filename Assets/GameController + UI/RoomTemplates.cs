using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] DownRooms, UpRooms, LeftRooms, RightRooms, EndRooms;
    public float timer = 10f; //One round of rooms per second
    public bool endSpawning = false;
    [HideInInspector]public List<GameObject> rooms = new List<GameObject>();

    private void Update()
    {
        if (timer > 0) 
        { 
            timer -= Time.deltaTime;
        }
        else
        {
            endSpawning = true; 
        }
    }
}
