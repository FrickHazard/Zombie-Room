using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public Room roomPrefab;

    private int maxSize = 7;
    private int minSize = 3;

    private RoomData CreateRoom(bool leftRoom, bool rightRoom, bool upRoom, bool downRoom)
    {
        int width = Random.Range(minSize, maxSize);
        int height = Random.Range(minSize, maxSize);
        var roomData = DataFactory.CreateRoomData(width, height);
        List<ExitData> exits = new List<ExitData>();
        if (leftRoom)
        {
            var location = new Vector2(-(float)roomData.Width / 2, 0);
            var exitData = DataFactory.CreateExitData(location, roomData.ID, ExitDirection.West);
            exits.Add(exitData);
        }
        if (rightRoom)
        {
            var location = new Vector2((float)roomData.Width / 2, 0);
            var exitData = DataFactory.CreateExitData(location, roomData.ID, ExitDirection.East);
            exits.Add(exitData);
        }
        if (upRoom)
        {
            var location = new Vector2(0, (float)roomData.Height / 2);
            var exitData = DataFactory.CreateExitData(location, roomData.ID, ExitDirection.North);
            exits.Add(exitData);
        }
        if (downRoom)
        {
            var location = new Vector2(0, -(float)roomData.Height / 2);
            var exitData = DataFactory.CreateExitData(location, roomData.ID, ExitDirection.South);
            exits.Add(exitData);
        }
        roomData.SetExitIDs(exits.ToArray());
        return roomData;
    }

    public void BuildRoomFromExit(ExitData exitData)
    {
        bool leftRoom = false;
        bool rightRoom = false;
        bool upRoom = false;
        bool downRoom = false;
        switch (exitData.Direction)
        {
            case ExitDirection.North:
                {
                    downRoom = true;
                    break;

                }
            case ExitDirection.South:
                {
                    upRoom = true;
                    break;
                }
            case ExitDirection.East:
                {
                    leftRoom = true;
                    break;
                }
            case ExitDirection.West:
                {
                    rightRoom = true;
                    break;
                }
        }
        if (!leftRoom) leftRoom = (Random.value > 0.5f);
        if (!rightRoom) rightRoom = (Random.value > 0.5f);
        if (!upRoom) upRoom = (Random.value > 0.5f);
        if (!downRoom) downRoom = (Random.value > 0.5f);
        CreateRoom(leftRoom, rightRoom, upRoom, downRoom);
    }


    private void Start()
    {
        var rootRoomData = CreateRoom(true, true, true, true);
        GameState.SetRoomData(rootRoomData);
    }
}
