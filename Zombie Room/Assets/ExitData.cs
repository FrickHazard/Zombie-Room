using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ExitData {
    public int RoomId;
    public int CorrespondingExitId;
    public Vector2 Location;
    public ExitDirection Direction;
    public int ID;

    public ExitData(int roomId, Vector2 location, int id, ExitDirection direction)
    {
        Direction = direction;
        RoomId = roomId;
        CorrespondingExitId = -1;
        Location = location;
        ID = id;
    }

    public void SetCorrespondingExitID(int id)
    {
        CorrespondingExitId = id;
    }
}
