using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;
using System;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using UnityEngine.UIElements;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine.Animations;
using UnityEditor;

public class AimControl : MonoBehaviour
{
    public SpriteRenderer CharacterSpriteColor;
    private SpriteRenderer sprite;
    public Vector2 pointing;
    public float angle;
    Camera mainCam;
    float offsetX = -1;
    void Start()
    {
        mainCam = Camera.main;
        sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = 2;
        sprite.color =  CharacterSpriteColor.color;
    }
    private void Update()
    {
        //Flìp
        if (pointing.x >= 0)
        {
            sprite.flipX = false;
            transform.eulerAngles = Vector3.forward * angle;
        } else
        {
            sprite.flipX= true;
            transform.eulerAngles = Vector3.forward * ((180 - angle)*-1);
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
                sprite.sortingOrder = 0;
            }
            else
            {
                angle = 360 - (Vector2.Angle(pointing, new Vector2(1, 0)));
                sprite.sortingOrder = 1;
            }
        }
    }
    public void AimMouse(InputAction.CallbackContext ctx)
    {

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 20;
        mousePosition = mainCam.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition + new Vector3(offsetX, 0, 0);
    }
}
