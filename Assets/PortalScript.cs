using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Hatted")
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject p in players)
            {
                p.transform.position = Vector3.zero;
            }
            players = GameObject.FindGameObjectsWithTag("Hatted");
            foreach (GameObject p in players)
            {
                p.transform.position = Vector3.zero;
            }
            GameObject.FindWithTag("GameController").transform.position = Vector3.zero;
         // GameObject.FindWithTag("MainCamera").transform.position = Vector3.zero;
            SceneManager.LoadScene("ToNextLevel");
        }
    }
}
