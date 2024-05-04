using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeManager : MonoBehaviour
{
    StatsUpdater enemy;
    public GameObject heartDrop;
    void Start()
    {
        enemy = GetComponent<StatsUpdater>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            enemy.life -= collision.GetComponent<Bullet>().damage;

            if (collision.GetComponent<Bullet>().freeze == true)
            {
                enemy.isFreezed = true;
            }
            if (collision.GetComponent<Bullet>().burn == true)
            {
                enemy.isBurning = true;
            }
            if (collision.GetComponent<Bullet>().freeze == true)
            {
                enemy.isPoisoned = true;
            }

            Destroy(collision.gameObject);
            if(enemy.life <= 0)
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
        if (UnityEngine.Random.Range(0, 101) <= 5) //Create a heart 100% drop rate
        {
            Debug.Log("Created");
            if (UnityEngine.Random.Range(0, 101) <= 20) //Purple 20% - Red 80%
            {
                isRed = false;
                Debug.Log("purple");
            }
            else
            {
                isRed = true;
                Debug.Log("red");
            }
            GameObject newHeart = Instantiate(heartDrop, transform.position, Quaternion.identity);
            Debug.Log("Instantiated");
            newHeart.GetComponent<HeartManager>().InitializeHeart(UnityEngine.Random.Range(1,3), isRed);
            Debug.Log("Init");
        }
    }
}
