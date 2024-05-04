using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public float healAmount;
    public bool isRed;

    GameObject playerObjective;
    public GameObject heartColl;
    public void InitializeHeart(int healAmount, bool isRed)
    {
        this.healAmount = (float)healAmount;
        this.isRed = isRed;
    }
    private void Update()
    {
        if (heartColl.IsDestroyed())
        {
            Destroy(gameObject);
        }
        if (playerObjective != null)
        {
            MoveTowards(playerObjective.transform.position);
        }
        GetComponent<Animator>().SetBool("isRed", isRed);
        GetComponent<Animator>().SetFloat("healAmount", healAmount);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.tag == "Player" || collision.tag == "Hatted") && playerObjective == null)
        {
            if (isRed && (collision.GetComponent<StatsUpdater>().maxLife - collision.GetComponent<StatsUpdater>().r_hearts) >= healAmount )
            {
                playerObjective = collision.gameObject;
            }
            if (!isRed)
            {
                playerObjective = collision.gameObject;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerObjective = null;
    }
    void MoveTowards(Vector2 targetPosition)
    {
        Vector3 direction = (targetPosition - (Vector2)transform.position).normalized;
        Vector3 finalPos = transform.position + (direction * 1f * Time.deltaTime);
        transform.position = finalPos;
    }
    

}
