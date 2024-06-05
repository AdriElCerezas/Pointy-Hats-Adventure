using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnActivator : MonoBehaviour
{
    public RoomInitiator roomInitiator;
    void Awake()
    {
        roomInitiator.onSpawn = ActivateSpawners;
    }

    void ActivateSpawners(bool closed)
    {
        Debug.Log("Door:" + closed);
        if (closed)
        {
            SummonCircle[] spawners = GetComponentsInChildren<SummonCircle>();
            foreach (SummonCircle spawner in spawners)
            {
                spawner.Summon();
            }
        }
    }
}
