using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoomToList : MonoBehaviour
{
    // Start is called before the first frame update
    private RoomTemplates roomTemplates;
    int n;
    void Awake()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("RoomTemplate").GetComponent<RoomTemplates>();
        roomTemplates.rooms.Add(gameObject);
        n = roomTemplates.rooms.Count;
    }
    private void Start()
    {
        gameObject.name = ($"Room - {n}");
    }
}
