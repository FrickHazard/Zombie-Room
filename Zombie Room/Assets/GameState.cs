using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState {

    private static int PlayerHealth = -1;
    private static int PlayerArmor= -1;
    private static bool RoomIsActive;
    private static CameraController CameraController;
    private static bool _cameraControllerRegistered = false;

    public static void RegisterCameraController(CameraController camController)
    {
        if (_cameraControllerRegistered) throw new InvalidOperationException("A camera was already registered");
        CameraController = camController;
        _cameraControllerRegistered = true;
    }

    public static void FocusCameraToRoom(Room room)
    {
        CameraController.CenterCameraOnRoom(room);
    }

}
