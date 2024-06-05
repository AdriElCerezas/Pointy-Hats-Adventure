using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openSide;
    //1 -> UP
    //2 -> RIGHT
    //3 -> DOWN
    //4 -> LEFT
    private RoomTemplates roomTemplates;
    int r;
    private void Start()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("RoomTemplate").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.2f);
    }
    public void Spawn()
    {
        if (openSide == 1)
        {
            //1 -> UP
            r = Random.Range(0, roomTemplates.UpRooms.Length);
            Instantiate(roomTemplates.UpRooms[r], transform.position, roomTemplates.UpRooms[r].transform.rotation);
        }
        else if (openSide == 2)
        {
            //2 -> RIGHT
            r = Random.Range(0, roomTemplates.RightRooms.Length);
            Instantiate(roomTemplates.RightRooms[r], transform.position, roomTemplates.RightRooms[r].transform.rotation);
        }
        else if(openSide == 3)
        {
            //3 -> DOWN
            r = Random.Range(0, roomTemplates.DownRooms.Length);
            Instantiate(roomTemplates.DownRooms[r], transform.position, roomTemplates.DownRooms[r].transform.rotation);
        }
        else if( openSide == 4)
        {
            //4 -> LEFT
            r = Random.Range(0, roomTemplates.LeftRooms.Length);
            Instantiate(roomTemplates.LeftRooms[r], transform.position, roomTemplates.LeftRooms[r].transform.rotation);
        }
    }
}
