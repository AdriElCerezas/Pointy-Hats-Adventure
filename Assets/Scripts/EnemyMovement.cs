using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EnemyMovement : MonoBehaviour
{
    public BoxCollider2D hitBox;
    public BoxCollider2D feet;
    public StatsUpdater enemyStats;
    Rigidbody2D rb;

    //Movimiento
    Vector2 direction;
    Vector2 finalPos;

    void Start()
    {
        //Movimiento
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        // Obtener todos los jugadores vivos
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject choosenPlayer = PlayerSelector(players);

        // Si se encontró un jugador cercano, mover al enemigo hacia su posición
        if (choosenPlayer != null)
        {
            MoveTowards(choosenPlayer.transform.position);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(finalPos);
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

    void MoveTowards(Vector2 targetPosition)
    {
        // Calcular la dirección hacia el jugador
        direction = (targetPosition - (Vector2)transform.position).normalized;
        finalPos = rb.position + (direction * enemyStats.speed * Time.deltaTime);
    }
}
