using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeManager : MonoBehaviour
{
    StatsUpdater enemy;
    public GameObject heartDrop;
    public int heartDropRate = 5;
    void Start()
    {
        enemy = GetComponent<StatsUpdater>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            enemy.Life -= collision.GetComponent<Bullet>().damage;

            Destroy(collision.gameObject);
            if(enemy.Life <= 0)
            {
                DropLoot();
                Destroy(gameObject);
            }
        }
    }

    void DropLoot()
    {
        //Heart gen
        bool isRed;
    
        if (UnityEngine.Random.Range(0, 101) <= heartDropRate) //Create a heart 100% drop rate
        {
            if (UnityEngine.Random.Range(0, 101) <= 20) //Purple 20% - Red 80%
            {
                isRed = false;
            }
            else
            {
                isRed = true;
            }
            GameObject newHeart = Instantiate(heartDrop, transform.position, Quaternion.identity);
            newHeart.GetComponent<HeartManager>().InitializeHeart(UnityEngine.Random.Range(1,3), isRed);
        }
    }
}
