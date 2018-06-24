using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        GameState.RegisterCameraController(this);
    }

    public void CenterCameraOnRoom(RoomData roomData)
    {
        var aspect = cam.aspect;
        if (roomData.Height > roomData.Width / aspect)
        {
            cam.orthographicSize = (float)roomData.Height / 2;
        }
        else
        {
            cam.orthographicSize = ((float)roomData.Width / aspect) / 2;
        }     
    }
}
