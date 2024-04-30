using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUpdater : MonoBehaviour
{
    public Stats playerStats;
    public int life;
    public int baseSpeed;
    public int speed;
    public int baseDashSpeed;
    public int dashSpeed;
    public float rangeRadius;
    public bool isFreezed;
    public bool isBurning;
    public bool isPoisoned;
    public bool isHatted;
    public float acuracy;
    public Collider2D feet;
    public Collider2D hitbox;
    public Rigidbody2D rb;
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        life = playerStats.life;
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
