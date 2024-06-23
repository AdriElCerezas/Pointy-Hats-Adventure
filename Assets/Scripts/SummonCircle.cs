using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonCircle : MonoBehaviour
{
    public GameObject summonedEnemy;
    public List<GameObject> enemies;
    Animator animator;
    System.Random alea = new System.Random();
    public float spawnTime;
    float spawnTimer = 3;
    bool spawning = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        if (summonedEnemy == null)
        {
            summonedEnemy = enemies[alea.Next(0, enemies.Count)];
        }
        spawnTimer = spawnTime;
    }

    void Update()
    {
        if (spawning)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                spawning = false;
                spawnTimer = spawnTime;
                Summon();
            }
        }
    }
    public void Summon()
    {
        Instantiate(summonedEnemy, transform.position, Quaternion.identity);

        animator.SetBool("summoning", spawning);
    }
}
