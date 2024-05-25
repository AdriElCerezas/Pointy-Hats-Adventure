using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public PlayerManager pm;
    public GameObject Module1, Module2, Module3, Module4;
    public GameObject Player1, player2, Player3, Player4;
    private void Awake()
    {
        pm.onJoin = OnJoin;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OnPlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void OnJoin(int index, GameObject player)
    {
        Debug.Log(index);
        if (index >= 1)
        {
            Module1.SetActive(true);
        }
        if (index >= 2)
        {
            Module2.SetActive(true);
        }
        if (index >= 3)
        {
            Module3.SetActive(true);
        }
        if (index >= 4)
        {
            Module4.SetActive(true);
        }

        switch (index)
        {
            case 1:
                Player1.GetComponent<ColorSelector>().SetPlayer(player);
                break;
            case 2:
                player2.GetComponent<ColorSelector>().SetPlayer(player);
                break;
            case 3:
                Player3.GetComponent<ColorSelector>().SetPlayer(player);
                break;
            case 4:
                Player4.GetComponent<ColorSelector>().SetPlayer(player);
                break;
            default:
            break;
        }
    }
}
