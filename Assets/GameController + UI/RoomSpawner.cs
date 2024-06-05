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
    bool spawned = false;
    Vector3 spawningMod = new Vector3(-10, -10);
    private void Start()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("RoomTemplate").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.5f);
    }
    public void Spawn()
    {
        if (!spawned)
        {
            if (openSide == 1)
            {
                //1 -> UP
                r = Random.Range(0, roomTemplates.UpRooms.Length);
                Instantiate(roomTemplates.UpRooms[r], transform.position + spawningMod, roomTemplates.UpRooms[r].transform.rotation);
            }
            else if (openSide == 2)
            {
                //2 -> RIGHT
                r = Random.Range(0, roomTemplates.RightRooms.Length);
                Instantiate(roomTemplates.RightRooms[r], transform.position + spawningMod, roomTemplates.RightRooms[r].transform.rotation);
            }
            else if (openSide == 3)
            {
                //3 -> DOWN
                r = Random.Range(0, roomTemplates.DownRooms.Length);
                Instantiate(roomTemplates.DownRooms[r], transform.position + spawningMod, roomTemplates.DownRooms[r].transform.rotation);
            }
            else if (openSide == 4)
            {
                //4 -> LEFT
                r = Random.Range(0, roomTemplates.LeftRooms.Length);
                Instantiate(roomTemplates.LeftRooms[r], transform.position + spawningMod, roomTemplates.LeftRooms[r].transform.rotation);
            }
            spawned = true;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(gameObject.name + collision.name);
        if (collision.gameObject.tag == "Room")
        {
            Debug.Log("AutoDestroy");
            Destroy(gameObject.GetComponentInParent<Transform>().gameObject);
        }
    }
}
