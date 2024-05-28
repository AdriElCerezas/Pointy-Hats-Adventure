using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUpdater : MonoBehaviour
{
    public Stats playerStats;
    private int maxLife, life, p_hearts, r_hearts;
    public float baseSpeed;
    public float speed;
    public float baseDashSpeed;
    public float dashSpeed;
    public float rangeRadius;
    public bool isFreezed;
    public bool isBurning;
    public bool isPoisoned;
    public bool isHatted;
    public float acuracy;
    public Collider2D feet;
    public Collider2D hitbox;
    public Rigidbody2D rb;
    public Animator animator = null;
    public float fireRate;

    public Action<int> onPurpleHearts;
    public Action<int> onRedHearts;
    public Action<int> onMaxLife;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        maxLife = playerStats.maxLife;
        p_hearts = 0;
        r_hearts = MaxLife;
        life = P_hearts + R_hearts;
        baseSpeed = playerStats.baseSpeed;
        acuracy = playerStats.acuracy;
        speed = playerStats.speed;
        baseDashSpeed = playerStats.baseDashSpeed;
        dashSpeed = playerStats.dashSpeed;
        isFreezed = playerStats.isFreezed;
        isBurning = playerStats.isBurning;
        isPoisoned = playerStats.isPoisoned;
    }
    private void Start()
    {
        onRedHearts?.Invoke(R_hearts);
        onPurpleHearts?.Invoke(P_hearts);
        onMaxLife?.Invoke(MaxLife);
    }

    public int Life { get => life; set => life = value; }
    public int P_hearts 
    { 
        get => p_hearts; 
        set 
        {
            if (value !=  p_hearts)
            {
                p_hearts = value;
                onPurpleHearts.Invoke(value);
            }
        }
    }
    public int R_hearts { get => r_hearts; 
        set
        {
            if (value != r_hearts)
            {r_hearts = value;
                onRedHearts.Invoke(value);
            }
        }
    }
    public int MaxLife { get => maxLife; 
        set
        {
            if (value != maxLife)
            {
                maxLife = value;
                onMaxLife.Invoke(value);
            }
        }
    }

}
