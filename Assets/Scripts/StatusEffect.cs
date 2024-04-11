using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;
using System;

public class StatusEffect : MonoBehaviour
{
    public PlayerStats playerStats;
    public void Freeze(InputAction.CallbackContext ctx)
    {
        if (playerStats.isFreezed)
        {
            playerStats.isFreezed = false;
            playerStats.speed = playerStats.baseSpeed;
            playerStats.dashSpeed = playerStats.baseDashSpeed;
        }
        else
        {
            playerStats.speed = playerStats.baseSpeed / 2;
            playerStats.dashSpeed = playerStats.baseDashSpeed / 2;
            playerStats.isFreezed = true;
        }
    }
}
