using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitData {
    public RoomData Room;
    public ExitData CorrespondingExit = null;
    public Vector2 Location;
    public ExitDirection Direction;

    public ExitData(Vector2 location, ExitDirection direction)
    {
        Direction = direction;
        Location = location;
    }

    public void SetCorrespondingExit(ExitData exitData)
    {
        CorrespondingExit = exitData;
    }
}
