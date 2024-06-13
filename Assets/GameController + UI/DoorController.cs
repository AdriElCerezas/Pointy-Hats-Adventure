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
        roomInitiator.onDoorsClose = EventDelayer;
    }
    private void EventDelayer(bool toTransfer)
    {
        closed = toTransfer;
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
