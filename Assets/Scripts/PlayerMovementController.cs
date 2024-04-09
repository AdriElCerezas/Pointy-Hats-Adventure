/*using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    Vector2 moveInput;
    Vector2 movement;
    public Stats playerStats;
    float moveSpeed;
    Rigidbody2D rb;

    // Dash:
    public float dashSpeed = 20f;
    public bool dashAvilable = true;
    public float dashDuration = 0.1f; // Duración del dash reducida
    float dashTimer;

    void Start()
    {
        moveSpeed = playerStats.speed;
        rb = GetComponent<Rigidbody2D>();
        dashTimer = dashDuration;
    }
    void Update()
    {
        if (!dashAvilable)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
            {
                dashAvilable = true;
            }
        }
    }
    public void Move(InputAction.CallbackContext ctx)
    {
            moveInput = ctx.ReadValue<Vector2>();
            movement = new Vector2(moveInput.x, moveInput.y).normalized;

            if (movement != Vector2.zero)
            {
                rb.velocity = movement * moveSpeed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
    }
    public void Dash(InputAction.CallbackContext ctx)
    {
        if (dashAvilable)
        {
            dashAvilable = false;

            // Calcula la dirección del dash
            Vector2 dashDirection = movement.normalized;

            // Aplica una fuerza al Rigidbody2D en la dirección del dash
            rb.AddForce(dashDirection * dashSpeed, ForceMode2D.Impulse);
            rb.velocity = movement.normalized * dashSpeed;
        }
    }
}
*/
/*using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementController : MonoBehaviour
{
    //Movimiento
    Vector2 moveInput;
    Vector2 movement;
    public Stats playerStats;
    float moveSpeed;
    public Rigidbody2D rb;
    public BoxCollider2D hitBox;
    public BoxCollider2D feet;
    //Dash
    public float baseDashSpeed = 20f;
    float dashSpeed;
    public bool isDashing = false;
    Vector2 dashDirection;
    public float dashDuration = 0.1f;
    float dashTimer;

    public bool dashAvilable = true;
    public float cooldownDuration = 0.3f;
    float cooldownTimer;

    void Start()
    {
        //Movimiento
        moveSpeed = playerStats.baseSpeed;
        dashSpeed = baseDashSpeed;
        dashTimer = 0f;
        cooldownTimer = cooldownDuration;
    }
    void Update()
    {
        if(isDashing)
        {
            dashTimer -= Time.deltaTime;
            if(dashTimer <= 0 )
            {
                rb.AddForce(-dashDirection * dashSpeed, ForceMode2D.Impulse);
                isDashing = false;
            }
        }
        if(!dashAvilable)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                dashAvilable = true;
                hitBox.enabled = true;
            }
        }
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        if (!isDashing)
        {
            moveInput = ctx.ReadValue<Vector2>();
            movement = new Vector2(moveInput.x, moveInput.y).normalized;

            // Si el jugador no es invulnerable, moverse con normalidad
            if (movement != Vector2.zero)
            {
                rb.velocity = movement * moveSpeed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
    public void Dash(InputAction.CallbackContext ctx)
    {
        if(ctx.started && !isDashing && dashAvilable)
        {
            dashDirection = moveInput.normalized;
            hitBox.enabled = false;
            isDashing = true;
            dashAvilable = false;
            rb.AddForce(dashDirection * dashSpeed, ForceMode2D.Impulse);
            dashTimer = dashDuration;
            cooldownTimer = cooldownDuration;
        }
    }
    public void Freeze(InputAction.CallbackContext ctx)
    {
        if (playerStats.isFreezed)
        {
            playerStats.isFreezed = false;
            moveSpeed = playerStats.baseSpeed;
            dashSpeed = baseDashSpeed;
        } else
        {
            moveSpeed = playerStats.baseSpeed / 2;
            dashSpeed = baseDashSpeed / 2;
            playerStats.isFreezed = true;
        }
    }
}*/
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementController : MonoBehaviour
{
    //Movimiento
    Vector2 moveInput;
    Vector2 movement;
    public Stats playerStats;
    public float moveSpeed;
    public BoxCollider2D hitBox;
    public BoxCollider2D feet;

    //Dash
    public float baseDashSpeed = 20f;
    public float dashSpeed;
    public bool isDashing = false;
    Vector2 dashDirection;
    public float dashDuration = 0.1f;
    float dashTimer;

    public bool dashAvilable = true;
    public float cooldownDuration = 0.3f;
    float cooldownTimer;

    void Start()
    {
        //Movimiento
        moveSpeed = playerStats.baseSpeed;
        dashSpeed = baseDashSpeed;
        dashTimer = 0f;
        cooldownTimer = cooldownDuration;
    }
    void Update()
    {
        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
            {
                transform.Translate(Vector2.zero);
                isDashing = false;
            }
        } else
        {
            movement = new Vector2(moveInput.x, moveInput.y).normalized;
            transform.Translate(movement * moveSpeed * Time.deltaTime);
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
            dashDirection = moveInput.normalized;
            hitBox.enabled = false;
            isDashing = true;
            dashAvilable = false;
            transform.Translate(dashDirection * dashSpeed);
            dashTimer = dashDuration;
            cooldownTimer = cooldownDuration;
        }
    }//FIX 
    public void Freeze(InputAction.CallbackContext ctx)
    {
        if (playerStats.isFreezed)
        {
            playerStats.isFreezed = false;
            moveSpeed = playerStats.baseSpeed;
            dashSpeed = baseDashSpeed;
        }
        else
        {
            moveSpeed = playerStats.baseSpeed / 2;
            dashSpeed = baseDashSpeed / 2;
            playerStats.isFreezed = true;
        }
    }
}