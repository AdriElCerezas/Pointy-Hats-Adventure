using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public List<Transform> players = new List<Transform>();
    public GameObject cameraObj;
    private Color[] playerColors = { new Color(0f, 0f, 1f), new Color(0f, 1f, 0f), new Color(1f, 0f, 0f), new Color(0.7f, 0.2f, 1f) };
    // Start is called before the first frame update
    public void Update()
    {
        if (players.Count > 0)
        {
            UpdateCameraPosition();
        }
    }
    private void OnPlayerJoined(PlayerInput playerInput)
    {
        AddToList(playerInput.transform);
        //playerInput.GetComponent<SpriteRenderer>().color = Color().color;
        int playerIndex = players.Count - 1; // Índice del último jugador agregado
        SpriteRenderer playerRenderer = playerInput.GetComponent<SpriteRenderer>();
        if (playerRenderer != null)
        {
            playerRenderer.color = playerColors[playerIndex];
        }
    }
    private void OnPlayerLeft(PlayerInput playerInput)
    {
        Destroy(playerInput.gameObject);
    }
    void AddToList(Transform playerTransform)
    {
        players.Add(playerTransform);
    }
    void UpdateCameraPosition()
    {
        Vector2 midpoint = Vector2.zero; // Usamos Vector2 para operaciones en 2D

        foreach (Transform player in players)
        {
            midpoint += (Vector2)player.position; // Convertimos la posición del jugador a un Vector2
        }

        midpoint /= players.Count;

        // Ajustamos la posición de la cámara en 2D
        cameraObj.transform.position = new Vector3(midpoint.x, midpoint.y, cameraObj.transform.position.z);
    }

}
