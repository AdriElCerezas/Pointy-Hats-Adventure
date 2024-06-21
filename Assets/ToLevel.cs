using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel : MonoBehaviour
{
    public float timer = 3f;
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 )
        {
            ToNext();
        }
    }
    public void ToNext()
    {
        SceneManager.LoadScene("Level-1");
    }
}
