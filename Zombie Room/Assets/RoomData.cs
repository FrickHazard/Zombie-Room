using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct RoomData {
    public int Width;
    public int Height;
    public ExitData[] Exits;
    public int ID;

    public RoomData (int width, int height, int id) {
        Width = width;
        Height = height;
        Exits = new ExitData[0];
        ID = id;
    }

    public void SetExitIDs(ExitData[] exits)
    {
        Exits = exits;
    }
}
