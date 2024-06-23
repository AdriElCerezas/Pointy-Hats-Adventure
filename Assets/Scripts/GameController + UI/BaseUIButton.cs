using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class BaseUIButton : MonoBehaviour
{
    public Button baseButton;
    public EventSystem EventSystem;
    public void OnEnable()
    {
        baseButton.Select();
    }
}