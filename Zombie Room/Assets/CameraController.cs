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

    public void CenterCameraOnRoom(Room room)
    {
       var greaterBound = room.Height > room.Width ? room.Height : room.Width;
       cam.orthographicSize = (float)greaterBound / 2;
    }
}
