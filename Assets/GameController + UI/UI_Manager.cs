using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public PlayerManager pm;
    public GameObject Module1, Module2, Module3, Module4;
    public GameObject Player1, player2, Player3, Player4;
    public GameObject Hud1, Hud2, Hud3, Hud4;
    public Button StartButton;
    private void Awake()
    {
        pm.onJoin = OnJoin;
        StartButton.enabled = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartLoading()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
    }
    public void OnPlayButton()
    { 
        foreach (var p  in pm.players)
        {
            p.transform.position = Vector3.zero;
        }
        pm.enableShooting = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void OnJoin(int index, GameObject player)
    {
        Debug.Log(index);
        StartButton.enabled = true;
        if (index >= 1)
        {
            Module1.SetActive(true);
            Hud1.SetActive(true);
        }
        if (index >= 2)
        {
            Module2.SetActive(true);
            Hud2.SetActive(true);
        }
        if (index >= 3)
        {
            Module3.SetActive(true);
            Hud3.SetActive(true);
        }
        if (index >= 4)
        {
            Module4.SetActive(true);
            Hud4.SetActive(true);
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
