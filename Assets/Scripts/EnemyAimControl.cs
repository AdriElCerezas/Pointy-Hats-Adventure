using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UIElements;
using UnityEngine.Animations;
using UnityEditor;

public class EnemyAimControl : MonoBehaviour
{
    private SpriteRenderer sprite;
    public Vector2 pointing;
    public float angle;
    public Transform choosenPlayer;
    StatsUpdater enemy;
    public bool Shooting = false;
    EnemyMovement EnemyMovement;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = 2;
        enemy = GetComponentInParent<StatsUpdater>();
        EnemyMovement = GetComponentInParent<EnemyMovement>();
    }
    private void Update()
    {
        choosenPlayer = GetComponentInParent<SeekBehavior>().target;
        if (choosenPlayer != null && EnemyMovement.isChasing)
        {
            Shooting = true;
            GetAngle(choosenPlayer.transform.position);

            //sprite aiming
            if (pointing.x >= 0)
            {
                //sprite.flipX = false;
                transform.eulerAngles = Vector3.forward * angle;
            }
            else
            {
                //sprite.flipX = true;
                transform.eulerAngles = Vector3.forward * angle;
            }
        }
        else
        {
            Shooting=false;
        }
    }


    void GetAngle(Vector2 targetPosition)
    {
        // Calcular la direcci�n hacia el jugador
        pointing = (targetPosition - (Vector2)transform.position).normalized;
        if (Shooting)
        {
            enemy.animator.SetFloat("Horizontal", pointing.x);
            enemy.animator.SetFloat("Vertical", pointing.y);
        }
        
        //Angle correction
        if (pointing.y >= 0)
        {
            angle = Vector2.Angle(pointing, new Vector2(1, 0));
            sprite.sortingOrder = 1;
        }
        else
        {
            angle = 360 - (Vector2.Angle(pointing, new Vector2(1, 0)));
            sprite.sortingOrder = 2;
        }
    }
}
