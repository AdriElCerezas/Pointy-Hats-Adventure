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
    public GameObject choosenPlayer;
    StatsUpdater enemy;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = 2;
        enemy = GetComponentInParent<StatsUpdater>();
    }
    private void Update()
    {
        //choosenPlayer = choosenPlayer;

        if (choosenPlayer != null)
        {
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
                transform.eulerAngles = Vector3.forward * angle; // * ((180 - angle) * -1);
            }
        }
    }

    void GetAngle(Vector2 targetPosition)
    {
        // Calcular la dirección hacia el jugador
        pointing = (targetPosition - (Vector2)transform.position).normalized;
        
        enemy.animator.SetFloat("Horizontal", pointing.x);
        enemy.animator.SetFloat("Vertical", pointing.y);
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
