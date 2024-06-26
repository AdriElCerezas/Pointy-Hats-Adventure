using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UIElements;
using UnityEngine.Animations;
using UnityEditor;
using static UnityEngine.EventSystems.EventTrigger;

public class AimControl : MonoBehaviour
{
    public SpriteRenderer CharacterSpriteColor;
    private SpriteRenderer sprite;
    public Vector2 pointing;
    public float angle = 0;
    public float acuracy = 100;
    Camera mainCam;
    bool mouse = false;
    Vector3 playerPos;
    Vector3 mousePos;
    StatsUpdater player;
    void Start()
    {
        player = GetComponentInParent<StatsUpdater>();
        mainCam = Camera.main;
        sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = 2;
    }
    private void Update()
    {
        if (mouse)
        {
            mousePos = Input.mousePosition;
            playerPos = GetComponentInParent<Transform>().position;
            mousePos = mainCam.ScreenToWorldPoint(mousePos);
            pointing = new Vector2(mousePos.x - playerPos.x, mousePos.y - playerPos.y);
            pointing.Normalize();

            player.animator.SetFloat("Horizontal", pointing.x);
            player.animator.SetFloat("Vertical", pointing.y);

            if (pointing.x != 0 && pointing.y != 0)
            {
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
        //Fl�p
        
        if (pointing.x >= 0)
        {
            //sprite.flipX = false;
            transform.eulerAngles = Vector3.forward * angle;
        } else
        {
            //sprite.flipX= true;
            transform.eulerAngles = Vector3.forward * angle; //* ((180 - angle)*-1);
        }

    }

    public void AimGamepad(InputAction.CallbackContext ctx)
    {
        pointing = ctx.ReadValue<Vector2>();
        if(pointing.x != 0 && pointing.y != 0)
        {
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
            player.animator.SetFloat("Horizontal", pointing.x);
            player.animator.SetFloat("Vertical", pointing.y);
        }
    }
    public void AimMouse(InputAction.CallbackContext ctx)
    {
        mouse = true;
    }
}
