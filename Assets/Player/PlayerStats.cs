using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Stats playerStats;
    public int life;
    public int baseSpeed;
    public int speed;
    public int baseDashSpeed;
    public int dashSpeed;
    public int acuracy;
    public int amo;
    public int maxAmo;
    public int charger;
    public float rangeRadius;
    public float fireRate;
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
        amo = playerStats.amo;
        maxAmo = playerStats.maxAmo;
        charger = playerStats.charger;
        rangeRadius = playerStats.rangeRadius;
        fireRate = playerStats.fireRate;
        isFreezed = playerStats.isFreezed;
        isBurning = playerStats.isBurning;
        isPoisoned = playerStats.isPoisoned;
    }
}
