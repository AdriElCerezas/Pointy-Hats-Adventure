using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public RoomInitiator roomInitiator;
    void Awake()
    {
        roomInitiator.onDoorsClose = ControlDoors;
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
