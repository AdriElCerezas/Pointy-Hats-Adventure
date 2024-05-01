using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    float fireTimer;
    public float bulletSpeed;
    public int damage;
    float angle;
    public bool freeze, burn, poison;
    public GameObject bullet;
    EnemyAimControl aim;
    StatsUpdater enemy;
    System.Random alea = new System.Random();

    float state, timerThird;
    private void Start()
    {
        aim = GetComponent<EnemyAimControl>();
        enemy = GetComponentInParent<StatsUpdater>();
        timerThird = (int)enemy.fireRate / 3;
    }
    // Update is called once per frame
    void Update()
    {
        if(aim.choosenPlayer != null)
        {
            fireTimer -= Time.deltaTime;
            if ( fireTimer < 2*timerThird && fireTimer >= timerThird)
            {
                state = 2;
            }
            if (fireTimer < timerThird)
            {
                state = 3;
            }
            if (fireTimer <= 0)
            {
                angle = aim.angle + alea.Next((int)(100-enemy.acuracy)*-1, (int)(100 - enemy.acuracy) *1);
                GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);


                Bullet bulletScript = newBullet.GetComponent<Bullet>();
                bulletScript.InitializeBullet(bulletSpeed, damage, freeze, burn, poison, angle, false);
                fireTimer = enemy.fireRate;
                state = 1;
            }
        }
        else
        {
            state = 1;
        }
        enemy.animator.SetFloat("State", state);
    }
}