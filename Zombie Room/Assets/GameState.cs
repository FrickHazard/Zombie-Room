using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState {

    private static int PlayerHealth = -1;
    private static int PlayerArmor= -1;
    private static bool RoomIsActive;
    private static CameraController CameraController;
    private static Room ActiveRoom;
    private static InputManager inputManager;
    private static bool _cameraControllerRegistered = false;
    private static bool _roomRegistered = false;
    private static bool _inputManagerRegistered = false;

    public static void RegisterCameraController(CameraController camController)
    {
        if (_cameraControllerRegistered) throw new InvalidOperationException("A camera was already registered");
        CameraController = camController;
        _cameraControllerRegistered = true;
    }
    
    public static void RegisterMainRoom(Room room)
    {
        if (_roomRegistered) throw new InvalidOperationException("A room was already registered");
        ActiveRoom = room;
        _roomRegistered = true;
    }

    public static void RegisterInputManager(InputManager inputManger)
    {
        if (_inputManagerRegistered) throw new InvalidOperationException("A room was already registered");
        inputManager = inputManger;
        _inputManagerRegistered = true;
    }

    public static void FocusCameraToRoom(RoomData roomData)
    {
        CameraController.CenterCameraOnRoom(roomData);
    }

    public static void SetRoomData(RoomData roomData)
    {
        ActiveRoom.SetFromData(roomData);
        FocusCameraToRoom(roomData);
    }

    public static Room GetActiveRoom()
    {
        return ActiveRoom;
    }
}
