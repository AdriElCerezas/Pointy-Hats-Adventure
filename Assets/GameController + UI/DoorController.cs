using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public RoomInitiator roomInitiator;
    void Awake()
    {
        roomInitiator = GetComponentInParent<RoomInitiator>();
        roomInitiator.onDoorsClose = ControlDoors;
    }
    private void Start()
    {
        
    }

    private void ControlDoors(bool closed)
    {
            SpriteRenderer[] roomDoor = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer door in roomDoor)
            {
                door.enabled = closed;
                door.GetComponent<Collider2D>().enabled = closed;
            }
    }
}
