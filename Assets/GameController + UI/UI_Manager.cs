using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public PlayerManager pm;
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
    public void OnJoin(int index)
    {
        
    }
}
