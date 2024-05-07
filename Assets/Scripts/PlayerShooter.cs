using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UIElements;
using UnityEngine.Animations;
using UnityEditor;
using static UnityEngine.EventSystems.EventTrigger;
public class PlayerShooter : MonoBehaviour
{
    AimControl aim;
    public GameObject bullet;
    StatsUpdater player;

    public float bulletSpeed;
    public int damage;
    public bool freeze;
    public bool burn;
    public bool poison;
    public float angle;
    float fireTimer;
    public Transform shootingPoint;
    private void Awake()
    {
        aim = GetComponent<AimControl>();
        player = GetComponentInParent<StatsUpdater>();
    }
    void Update()
    {     
        if (fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
        }
    }
    public void Shoot(InputAction.CallbackContext ctx) 
    {
        
        if (ctx.started && !GetComponentInParent<StatsUpdater>().isHatted && fireTimer <= 0)
        {
            angle = aim.angle;
            GameObject newBullet = Instantiate(bullet, shootingPoint.position, Quaternion.identity);


            Bullet bulletScript = newBullet.GetComponent<Bullet>();
            bulletScript.InitializeBullet(bulletSpeed, damage, freeze, burn, poison, angle, true);
            fireTimer = player.fireRate;
        }
    }
    
}
