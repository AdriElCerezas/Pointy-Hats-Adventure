using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnActivator : MonoBehaviour
{
    public RoomInitiator roomInitiator;
    void Awake()
    {
        roomInitiator = GetComponentInParent<RoomInitiator>();
        roomInitiator.onSpawn = ActivateSpawners;
    }
    private void Start()
    {
        
    }

    void ActivateSpawners(bool closed)
    {
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
