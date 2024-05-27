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
        int playerIndex = players.Count - 1;
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
        Vector2 midpoint = Vector2.zero;

        foreach (Transform player in players)
        {
            midpoint += (Vector2)player.position;
        }

        midpoint /= players.Count;
        Vector3 desiredCameraPosition = new Vector3(midpoint.x, midpoint.y, cameraObj.transform.position.z);

        //Suavizado de movimiento
        cameraObj.transform.position = Vector3.Lerp(cameraObj.transform.position, desiredCameraPosition, 0.1f * smoothness);
    }


}
