using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] DownRooms, UpRooms, LeftRooms, RightRooms, EndRooms;
    public float timer = 5f; //Two round of rooms per second
    public bool endSpawning = false;
    public List<GameObject> rooms = new List<GameObject>();
    public GameObject PortalPrefab;

    bool justOnce = false;
    private void Update()
    {
        if (timer > -3.5f) 
        { 
            timer -= Time.deltaTime;
        }
        if(timer < 0)
        {
            endSpawning = true; 
        }
        if (timer < -3.5f && !justOnce && endSpawning)
        {
            justOnce = true;
            Instantiate(PortalPrefab, rooms[rooms.Count - 1].transform.position + new Vector3(10, 10, 0), Quaternion.identity);
            Component[] finalRoom = rooms[rooms.Count - 1].GetComponentsInChildren<Component>(); 
            foreach (var s in finalRoom)
            {
                Debug.Log(s.name);
                if(s.name == "Spawners")
                {
                    Destroy(s.gameObject);
                }
            }
        }
    }
}
