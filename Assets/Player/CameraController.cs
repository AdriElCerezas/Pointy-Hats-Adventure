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
    public CameraFreeze CameraFreeze;
    public Color[] playerColors = new Color[4];
    public Texture2D cursorTexture;
    private Vector2 cursorHotspot;
    public float smoothness = 1.0f;
    public bool freezeCamera;


    public void Start()
    {
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }
    public void Update()
    {
        freezeCamera = CameraFreeze.IsFrozen();
        if (players.Count > 0)
        {
            if (!freezeCamera)
            {
                UpdateCameraPosition();
            }
        }
    }
    private void OnPlayerJoined(PlayerInput playerInput)
    {
        
        AddToList(playerInput.transform);
        //playerInput.GetComponent<SpriteRenderer>().color = Color().color;
        int playerIndex = players.Count - 1; // �ndice del �ltimo jugador agregado
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
    /*void UpdateCameraPosition()
    {
        Vector2 midpoint = Vector2.zero; // Usamos Vector2 para operaciones en 2D

        foreach (Transform player in players)
        {
            midpoint += (Vector2)player.position; // Convertimos la posici�n del jugador a un Vector2
        }

        midpoint /= players.Count;

        // Ajustamos la posici�n de la c�mara en 2D
        cameraObj.transform.position = new Vector3(midpoint.x, midpoint.y, cameraObj.transform.position.z);
    }*/
    void UpdateCameraPosition()
    {
        Vector2 midpoint = Vector2.zero; // Usamos Vector2 para operaciones en 2D

        foreach (Transform player in players)
        {
            midpoint += (Vector2)player.position; // Convertimos la posici�n del jugador a un Vector2
        }

        midpoint /= players.Count;

        // Obtenemos la posici�n deseada de la c�mara
        Vector3 desiredCameraPosition = new Vector3(midpoint.x, midpoint.y, cameraObj.transform.position.z);

        // Suavizamos el movimiento de la c�mara interpolando entre la posici�n actual y la deseada
        cameraObj.transform.position = Vector3.Lerp(cameraObj.transform.position, desiredCameraPosition, Time.deltaTime * smoothness);
    }


}
