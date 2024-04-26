using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float fireRate;
    float fireTimer;
    public float bulletSpeed;
    public int damage;
    public float angle;
    public bool freeze, burn, poison;
    public GameObject bullet;
    public EnemyAimControl aim;

    // Update is called once per frame
    void Update()
    {
        if(aim.choosenPlayer != null)
        {
            fireTimer -= Time.deltaTime;
            if (fireTimer <= 0)
            {
                angle = aim.angle;
                GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);


                Bullet bulletScript = newBullet.GetComponent<Bullet>();
                bulletScript.InitializeBullet(bulletSpeed, damage, freeze, burn, poison, angle, false);
                fireTimer = fireRate;
            }
        }
    }
}
