using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    public GameObject HUD_heart;
    GameObject player;
    public int Index;
    public PlayerManager pManager;

    int health, maxHealth, pHealth;
    List<HealthHeart> hearts = new List<HealthHeart>();


    private void Awake()
    {
        player = pManager.players[Index];
    }
    private void Update()
    {
        DrawHearts();
    }
    public void DrawHearts()
    {
        ClearHearts();
        health = player.GetComponent<StatsUpdater>().r_hearts;
        maxHealth = player.GetComponent<StatsUpdater>().maxLife;
        pHealth = player.GetComponent<StatsUpdater>().P_hearts;
        int halfR = health % 2;
        int halfP = pHealth % 2;

        for (int i = 0; i < (health/2) - halfR; i++) //FullHeart
        {
            CreateHeart(2, false);
        }
        for (int i = 0; i < halfR; i++) //HalfHeart
        {
            CreateHeart(1, false);
        }
        if (health < maxHealth) //EmptyHeart
        {
            for (int i = 0; i < ((maxHealth-health-halfR)/2); i++)
            {
                CreateHeart(0, false);
            }
        }

        for (int i = 0; i < (int)(pHealth / 2) - halfP; i++) //FullPheart
        {
            CreateHeart(2, true);
        }
        for (int i = 0; i < halfP; i++) //HalfPheart
        {
            CreateHeart(1, true);
        }
    }

    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();
    }
    public void CreateHeart(int health, bool isPurple)
    {
        GameObject newHeart = Instantiate(HUD_heart);
        newHeart.transform.SetParent(transform);

        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(health, isPurple);
        hearts.Add(heartComponent);
    }

}
