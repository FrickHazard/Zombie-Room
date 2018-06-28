using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState {


    public static float PlayerSpeed { get { return playerSpeed; } }
    private static float playerSpeed = 0.1f;

    public static float PlayerHealth { get { return playerHealth; } }
    private static int playerHealth = -1;

    public static float PlayerArmor { get { return playerArmor; } }
    private static int playerArmor = -1;

    private static bool playerInMovementTowardExit = false;

    private static ExitData exitPlayerIsMovingTowards = null;
    // register stuff
    private static CameraController CameraController;
    private static RoomVisual roomVisual;
    private static InputManager inputManager;
    private static PlayerEntity playerEntity;
    private static RoomBackground roomBackground;


    public static void RegisterCameraController(CameraController camController)
    {
        if (CameraController) throw new InvalidOperationException("A camera was already registered");
        CameraController = camController;
    }
    
    public static void RegisterMainRoom(RoomVisual _activeRoom)
    {
        if (roomVisual) throw new InvalidOperationException("A room was already registered");
        roomVisual = _activeRoom;
    }

    public static void RegisterInputManager(InputManager _inputManager)
    {
        if (inputManager) throw new InvalidOperationException("A room was already registered");
        inputManager = _inputManager;
    }

    public static void RegisterPlayerEntity(PlayerEntity _playerEntity)
    {
        if (playerEntity) throw new InvalidOperationException("A player was already registered");
        playerEntity = _playerEntity;
    }

    public static void RegisterRoomBackground(RoomBackground background)
    {
        if (roomBackground) throw new InvalidOperationException("A room background was already registered");
        roomBackground = background;
    }

    public static void FocusCameraToRoom(RoomData roomData)
    {
        CameraController.CenterCameraOnRoom(roomData);
    }

    public static void SetRoomData(RoomData roomData)
    {
        roomVisual.SetFromData(roomData);
        roomBackground.SetFromData(roomData);
        FocusCameraToRoom(roomData);
    }

    public static RoomVisual GetActiveRoom()
    {
        return roomVisual;
    }

    public static void StartPlayerMovement(Vector2 target, ExitData exitData)
    {
        playerInMovementTowardExit = true;
        exitPlayerIsMovingTowards = exitData;
        playerEntity.StartMovement(target);
    }


    public static void OnEndPlayerMovement()
    {
        SetRoomData(exitPlayerIsMovingTowards.CorrespondingExit.Room);
        playerEntity.SetPlayerEntityPosition(exitPlayerIsMovingTowards.CorrespondingExit.Location);
        exitPlayerIsMovingTowards = null;
        playerInMovementTowardExit = false;
    }
}
