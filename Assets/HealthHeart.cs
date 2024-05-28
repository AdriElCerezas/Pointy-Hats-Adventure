using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeart : MonoBehaviour
{
    public Sprite rFull, rHalf, rEmpty;
    public Sprite pFull, pHalf;
    Image heartImage;
    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }
    public void SetHeartImage(int status, bool isPurple)
    {
        if (!isPurple)
        {
            switch (status)
            {
                case 0:
                    heartImage.sprite = rEmpty;
                    break;
                case 1:
                    heartImage.sprite = rEmpty;
                    break;
                case 2:
                    heartImage.sprite = rFull;
                    break;
            }
        }
    }
}
