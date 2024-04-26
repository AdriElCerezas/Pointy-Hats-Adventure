using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeManager : MonoBehaviour
{
    StatsUpdater enemy;
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
                Destroy(gameObject);
            }
        }
    }
}
