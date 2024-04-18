using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PlayerMovementController : MonoBehaviour
{
    //SetUp
    public BoxCollider2D hitBox;
    public BoxCollider2D feet;
    public PlayerStats playerStats;
    public int playerIndex;
    public Indexer indexer;

    //Movimiento
    Vector2 moveInput;
    Vector2 movement;
    Rigidbody2D rb;
    Vector2 finalPos;

    //Dash
    bool isDashing = false;
    Vector2 dashMovement;
    float dashDuration = 0.1f;
    float dashTimer;
    bool dashAvilable = true;
    float cooldownDuration = 0.3f;
    float cooldownTimer;

    void Start()
    {
        indexer = GameObject.Find("PlayerManager").GetComponent<Indexer>();
        playerIndex = indexer.SetIndex();
        //Movimiento
        dashTimer = 0f;
        cooldownTimer = cooldownDuration;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isDashing)
        {
            finalPos = new Vector2(transform.position.x, transform.position.y) + (movement * playerStats.dashSpeed * Time.deltaTime);
            dashMovement = movement;
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
            {
                isDashing = false;
            }
        } 
        if(!isDashing)
        {
            movement = new Vector2(moveInput.x, moveInput.y).normalized;
            finalPos = new Vector2(transform.position.x, transform.position.y) + (movement * playerStats.speed * Time.deltaTime);
        }
        if (!dashAvilable)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                dashAvilable = true;
                hitBox.enabled = true;
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
            hitBox.enabled = false;
            isDashing = true;
            dashAvilable = false;
            
            dashTimer = dashDuration;
            cooldownTimer = cooldownDuration;
        }
    }
}