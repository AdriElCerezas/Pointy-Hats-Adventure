using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ColorSelector : MonoBehaviour
{
    public GameObject player;
    public Color color;
    public int index;
    public Image ball;
    public Action<Color, int> onColorSet;

    public void SetPlayer(GameObject player)
    {
        this.player = player;
        SetColor(gameObject);
    }

    public void SetColor(GameObject newColor)
    {
        color = newColor.GetComponent<Image>().color;
        GetComponent<Image>().color = color;
        ball.color = color;
        onColorSet.Invoke(color, index);
    }
}
