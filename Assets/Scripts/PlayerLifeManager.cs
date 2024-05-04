using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{
    StatsUpdater player;

    private void Start()
    {
        player = GetComponent<StatsUpdater>();
    }
    private void Update()
    {
        player.life = player.r_hearts + player.p_hearts;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Disparo
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
        if (collision.tag == "Heart" && collision.IsTouching(player.hitbox))
        {
            Debug.Log("Heart touched");
            if (collision.GetComponentInParent<HeartManager>().isRed && (player.maxLife - player.r_hearts) >= GetComponentInParent<HeartManager>().healAmount)
            {
                player.r_hearts += (int)collision.GetComponentInParent<HeartManager>().healAmount;
                Destroy(collision.gameObject);
            }
            if (!collision.GetComponentInParent<HeartManager>().isRed)
            {
                player.p_hearts += (int)collision.GetComponentInParent<HeartManager>().healAmount;
                Destroy(collision.gameObject);
            }
        }
    }
}
