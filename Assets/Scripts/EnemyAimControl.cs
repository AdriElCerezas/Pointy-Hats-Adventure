using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UIElements;
using UnityEngine.Animations;
using UnityEditor;

public class EnemyAimControl : MonoBehaviour
{
    public SpriteRenderer CharacterSpriteColor;
    private SpriteRenderer sprite;
    public Vector2 pointing;
    public float angle;
    GameObject choosenPlayer;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = 2;
    }
    private void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        choosenPlayer = PlayerSelector(players);

        if (choosenPlayer != null)
        {
            GetAngle(choosenPlayer.transform.position);

            //sprite aiming
            if (pointing.x >= 0)
            {
                sprite.flipX = false;
                transform.eulerAngles = Vector3.forward * angle;
            }
            else
            {
                sprite.flipX = true;
                transform.eulerAngles = Vector3.forward * ((180 - angle) * -1);
            }
        }
    }

    GameObject PlayerSelector(GameObject[] players)
    {
        GameObject closestPlayer = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayer = player;
            }
        }

        return closestPlayer;
    }

    void GetAngle(Vector2 targetPosition)
    {
        // Calcular la dirección hacia el jugador
        pointing = (targetPosition - (Vector2)transform.position).normalized;

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
