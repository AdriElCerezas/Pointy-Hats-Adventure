using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D.Animation;

public class CameraController : MonoBehaviour
{
    public List<Transform> players = new List<Transform>();
    public GameObject cameraObj;
    public Color[] playerColors = new Color[4];
    public Texture2D cursorTexture;
    private Vector2 cursorHotspot;


    public void Start()
    {
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }
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
