using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PlayerMovementController : MonoBehaviour
{
    //SetUp
    public StatsUpdater playerStats;
    public int playerIndex;
    public Indexer indexer;
    Rigidbody2D rb;

    //Movimiento
    Vector2 moveInput;
    Vector2 movement;
    Vector2 finalPos;

    //Dash
    bool isDashing = false;
    Vector2 dashMovement;
    float dashDuration = 0.1f;
    float dashTimer;
    bool dashAvilable = true;
    float cooldownDuration = 0.5f;
    public float cooldownTimer;

    void Start()
    {
        playerStats.isHatted = false;
        indexer = GameObject.Find("PlayerManager").GetComponent<Indexer>();
        playerIndex = indexer.SetIndex();
        //Movimiento
        dashTimer = 0f;
        cooldownTimer = cooldownDuration;
        rb = playerStats.rb;
    }
    void Update()
    {
        if (isDashing)
        {
            finalPos = rb.position + (dashMovement * playerStats.dashSpeed * Time.deltaTime);
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
            {
                isDashing = false;
            }
        }
        else
        {
            movement = new Vector2(moveInput.x, moveInput.y).normalized;
            finalPos = rb.position + (movement * playerStats.speed * Time.deltaTime);
        }
        if (!dashAvilable)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                dashAvilable = true;
                if (!playerStats.isHatted)
                {
                    playerStats.hitbox.enabled = true;
                }
            }
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(finalPos);
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        if (!isDashing)
        {
            moveInput = ctx.ReadValue<Vector2>();
        }
    }
    public void Dash(InputAction.CallbackContext ctx)
    {
        if (ctx.started && !isDashing && dashAvilable)
        {
            dashMovement = movement;
            playerStats.hitbox.enabled = false;
            isDashing = true;
            dashAvilable = false;

            dashTimer = dashDuration;
            cooldownTimer = cooldownDuration;
        }
    }
}
