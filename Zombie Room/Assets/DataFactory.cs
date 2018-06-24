using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataFactory {
    private static int currentRoomId = -1;
    private static int currentExitId = -1;

    private static int GetNextRoomId()
    {
        currentRoomId++;
        return currentRoomId;
    }

    private static int GetNextExitId()
    {
        currentExitId++;
        return currentExitId;
    }

    public static RoomData CreateRoomData(int width, int height)
    {
        return new RoomData(width, height, GetNextRoomId());
    }

    public static ExitData CreateExitData(Vector2 location, int roomId, ExitDirection direction)
    {
        return new ExitData(roomId, location, GetNextExitId(), direction);
    }
}
