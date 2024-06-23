using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public RoomInitiator roomInitiator;
    bool closed = false;
    void Awake()
    {
        roomInitiator = GetComponentInParent<RoomInitiator>();
        roomInitiator.onDoorsClose = DelayEvent;
    }
    private void Start()
    {
        
    }
    private void DelayEvent(bool closed)
    {
     this.closed = closed;
        Invoke("ControlDoors", 0.5f);
    }
    private void ControlDoors()
    {
        SpriteRenderer[] roomDoor = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer door in roomDoor)
        {
            door.enabled = closed;
            door.GetComponent<Collider2D>().enabled = closed;
        }
    }
}
