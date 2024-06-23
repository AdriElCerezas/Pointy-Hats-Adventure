using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> destroyableObjects = new List<GameObject>();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("GameController"))
        {
            destroyableObjects.Add(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
        {
            destroyableObjects.Add(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Hatted"))
        {
            destroyableObjects.Add(obj);
        }
        

        foreach (GameObject g in destroyableObjects)
        {
            Destroy(g);
        }
        Invoke("StartGame", 5f);
    }

    void StartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
