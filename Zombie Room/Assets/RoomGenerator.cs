using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    private const int maxSize = 7;
    private const int minSize = 3;

    private const int minRoomCount = 20;
    private const int maxRoomCount = 50;

    // global scope variables
    private int openPaths;
    private int roomCount;
    private int roomCounter;

    private bool generateIsExitOpen(bool open)
    {
        if (open) return true;
        if (roomCounter >= roomCount) return false;
        if (openPaths < 1)
        {
            openPaths++;
            roomCounter++;
            return true;
        }
        var result = (Random.value > 0.5f);
        if (result)
        {
            openPaths++;
            roomCounter++;
        }
        else openPaths--;
        return result;
    }

    private RoomData BuildRootRoom()
    {
        int width = Random.Range(minSize, maxSize);
        int height = Random.Range(minSize, maxSize);
        var roomData = new RoomData(width, height);
        List<ExitData> exits = new List<ExitData>();
        exits.Add(new ExitData(new Vector2(-(float)roomData.Width / 2, 0), ExitDirection.West));
        exits.Add(new ExitData(new Vector2((float)roomData.Width / 2, 0), ExitDirection.East));     
        exits.Add(new ExitData(new Vector2(0, (float)roomData.Height / 2), ExitDirection.North));
        exits.Add(new ExitData(new Vector2(0, -(float)roomData.Height / 2), ExitDirection.South));
        roomData.SetExits(exits.ToArray());
        return roomData;
    }

    private RoomData BuildRoomFromExit(ExitData sourceExit)
    {
        bool leftRoom = false;
        bool rightRoom = false;
        bool upRoom = false;
        bool downRoom = false;
        // door to where we came from
        switch (sourceExit.Direction)
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
        leftRoom = generateIsExitOpen(leftRoom);
        rightRoom = generateIsExitOpen(rightRoom);
        upRoom = generateIsExitOpen(upRoom);
        downRoom = generateIsExitOpen(downRoom);
        int width = Random.Range(minSize, maxSize);
        int height = Random.Range(minSize, maxSize);
        var roomData = new RoomData(width, height);
        List<ExitData> exits = new List<ExitData>();
        if (leftRoom)
        {
            var location = new Vector2(-(float)roomData.Width / 2, 0);
            var exit = new ExitData(location, ExitDirection.West);
            exits.Add(exit);
            if (sourceExit.Direction == ExitDirection.East)
            {
                sourceExit.SetCorrespondingExit(exit);
                exit.SetCorrespondingExit(sourceExit);
            }
        }
        if (rightRoom)
        {
            var location = new Vector2((float)roomData.Width / 2, 0);
            var exit = new ExitData(location, ExitDirection.East);
            exits.Add(exit);
            if (sourceExit.Direction == ExitDirection.West)
            {
                sourceExit.SetCorrespondingExit(exit);
                exit.SetCorrespondingExit(sourceExit);
            }
        }
        if (upRoom)
        {
            var location = new Vector2(0, (float)roomData.Height / 2);
            var exit = new ExitData(location, ExitDirection.North);
            exits.Add(exit);
            if (sourceExit.Direction == ExitDirection.South)
            {
                sourceExit.SetCorrespondingExit(exit);
                exit.SetCorrespondingExit(sourceExit);
            }
        }
        if (downRoom)
        {
            var location = new Vector2(0, -(float)roomData.Height / 2);
            var exit = new ExitData(location, ExitDirection.South);
            exits.Add(exit);
            if (sourceExit.Direction == ExitDirection.North)
            {
                sourceExit.SetCorrespondingExit(exit);
                exit.SetCorrespondingExit(sourceExit);
            }
        }
        roomData.SetExits(exits.ToArray());
        return roomData;
    }



    private List<RoomData> ExpandFloor(RoomData rootRoomData)
    {
        roomCounter = 5;
        openPaths = 0;
        roomCount = Random.Range(minRoomCount, maxRoomCount);
        List<RoomData> totalRooms = new List<RoomData>(roomCount);
        List<RoomData> rooms = new List<RoomData>();
        foreach (ExitData exitData in rootRoomData.Exits)
        {
            rooms.Add(BuildRoomFromExit(exitData));
        }
        totalRooms.Add(rootRoomData);
        totalRooms.AddRange(rooms);
        while (rooms.Count > 0)
        {
            var newRooms = new List<RoomData>();
            foreach (RoomData roomData in rooms)
            {
                foreach (ExitData exitData in roomData.Exits)
                {
                    if (exitData.CorrespondingExit == null) newRooms.Add(BuildRoomFromExit(exitData));
                }
            }
            totalRooms.AddRange(newRooms);
            rooms = newRooms;
        }
        return totalRooms;
    }

    void Start()
    {
        var rooms = ExpandFloor(BuildRootRoom());
        GameState.SetRoomData(rooms[0]);
    }
}
