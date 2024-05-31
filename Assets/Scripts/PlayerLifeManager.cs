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
        player.Life = player.R_hearts + player.P_hearts;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Disparo
        if (collision.tag == "EnemyBullet" && gameObject.tag == "Player")
        {
            if (player.Life > 0)
            {
                if (player.P_hearts >= 1) //Daño a los morados
                {
                    player.P_hearts -= collision.GetComponent<Bullet>().damage;
                }
                else//Daño a rojos si no quedan morados
                {
                    player.P_hearts = 0;
                    player.R_hearts -= collision.GetComponent<Bullet>().damage;
                }

                Destroy(collision.gameObject);
            }
        }
        if (collision.tag == "Heart" && collision.IsTouching(player.hitbox))
        {
            Debug.Log("Heart touched");
            if (collision.GetComponentInParent<HeartManager>().isRed && (player.MaxLife - player.R_hearts) >= collision.GetComponentInParent<HeartManager>().healAmount)
            {
                player.R_hearts += (int)collision.GetComponentInParent<HeartManager>().healAmount;
                Destroy(collision.gameObject);
            }
            if (!collision.GetComponentInParent<HeartManager>().isRed)
            {
                player.P_hearts += (int)collision.GetComponentInParent<HeartManager>().healAmount;
                Destroy(collision.gameObject);
            }
        }
    }
}
