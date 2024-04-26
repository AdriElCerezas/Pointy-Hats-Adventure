using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UIElements;
using UnityEngine.Animations;
using UnityEditor;
public class PlayerShooter : MonoBehaviour
{
    public AimControl aim;
    public GameObject bullet;


    public float bulletSpeed;
    public int damage;
    public bool freeze;
    public bool burn;
    public bool poison;
    public float angle;

    public void Shoot(InputAction.CallbackContext ctx) 
    {
        if (ctx.started)
        {
            angle = aim.angle;
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);


            Bullet bulletScript = newBullet.GetComponent<Bullet>();
            bulletScript.InitializeBullet(bulletSpeed, damage, freeze, burn, poison, angle, true);
        }
    }
    
}
