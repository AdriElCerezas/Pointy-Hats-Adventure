using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{
    StatsUpdater player;

    private void Start()
    {
        player = GetComponent<StatsUpdater>();
    }

    //Hit by a bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            if (player.life > 0)
            {
                player.life -= collision.GetComponent<Bullet>().damage;

                if (collision.GetComponent<Bullet>().freeze == true)
                {
                    player.isFreezed = true;
                }
                if (collision.GetComponent<Bullet>().burn == true)
                {
                    player.isBurning = true;
                }
                if (collision.GetComponent<Bullet>().freeze == true)
                {
                    player.isPoisoned = true;
                }

                Destroy(collision.gameObject);
            }
        }
    }
}
