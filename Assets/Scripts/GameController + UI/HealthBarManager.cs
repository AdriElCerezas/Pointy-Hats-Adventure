using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public GameObject HUD_heart;
    public GameObject player;
    public int Index;
    public PlayerManager pManager;
    public Image ball;
    public Sprite live, hatted;

    int rHealth, maxHealth, pHealth;
    List<HealthHeart> hearts = new List<HealthHeart>();


    private void Awake()
    {
        player = pManager.players[Index];
        player.GetComponent<StatsUpdater>().onMaxLife = OnMaxLife;
        player.GetComponent<StatsUpdater>().onPurpleHearts = OnPurple;
        player.GetComponent<StatsUpdater>().onRedHearts = OnRed;
        ball.sprite = live;
    }
    public void DrawHearts()
    {
        ClearHearts();
        int halfR = rHealth % 2;
        int halfP = pHealth % 2;
        int fullR = (rHealth/2);
        int fullP = (pHealth/2);
        int empty = (maxHealth - rHealth) / 2;

        for(int i = 0; i < fullR; i++)
        {
            CreateHeart(2, false);
        }//Full Red
        for(int i = 0;i < halfR; i++)
        {
            CreateHeart(1, false);
        }//Half Red
        for (int i = 0; i < empty; i++)
        {
            CreateHeart(0, false);
        }//Empty Red
        for (int i = 0; i < fullP; i++)
        {
            CreateHeart(2, true);
        }//Full Purple
        for (int i = 0; i < halfP; i++)
        {
            CreateHeart(1, true);
        }//Half Purple

        isDead(pHealth + rHealth == 0);
        
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
    public void isDead(bool dead)
    {
        if (dead)
        {
            ball.sprite = hatted;
            ball.color = Color.grey + player.GetComponent<SpriteRenderer>().color;
        }
        else
        {
            ball.sprite = live;
            ball.color = player.GetComponent<SpriteRenderer>().color;
        }
    }
    void OnMaxLife(int maxLife)
    {
       maxHealth = maxLife;
       DrawHearts();
    }
    void OnPurple(int purple)
    {
        pHealth = purple;
        DrawHearts();
    }
    void OnRed(int red)
    {
        rHealth = red;
        DrawHearts();
    }
}
