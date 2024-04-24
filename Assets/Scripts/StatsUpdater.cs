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
    public int acuracy;
    public float rangeRadius;
    public bool isFreezed;
    public bool isBurning;
    public bool isPoisoned;
    void Start()
    {
        life = playerStats.life;
        baseSpeed = playerStats.baseSpeed;
        speed = playerStats.speed;
        baseDashSpeed = playerStats.baseDashSpeed;
        dashSpeed = playerStats.dashSpeed;
        acuracy = playerStats.acuracy;
        isFreezed = playerStats.isFreezed;
        isBurning = playerStats.isBurning;
        isPoisoned = playerStats.isPoisoned;
    }
}
