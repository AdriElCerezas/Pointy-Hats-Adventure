using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUpdater : MonoBehaviour
{
    public Stats playerStats;
    public int maxLife;
    public int life;
    public int p_hearts;
    public int r_hearts;
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
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        maxLife = playerStats.maxLife;
        p_hearts = 0;
        r_hearts = maxLife;
        life = p_hearts + r_hearts;
        baseSpeed = playerStats.baseSpeed;
        acuracy = playerStats.acuracy;
        speed = playerStats.speed;
        baseDashSpeed = playerStats.baseDashSpeed;
        dashSpeed = playerStats.dashSpeed;
        isFreezed = playerStats.isFreezed;
        isBurning = playerStats.isBurning;
        isPoisoned = playerStats.isPoisoned;
    }
}
