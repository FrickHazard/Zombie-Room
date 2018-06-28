using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData {
    public int Width;
    public int Height;
    public ExitData[] Exits;

    public RoomData (int width, int height) {
        Width = width;
        Height = height;
        Exits = new ExitData[0];
    }

    public void SetExits(ExitData[] exits)
    {
        foreach (ExitData exitData in exits)
        {
            exitData.Room = this;
        }
        Exits = exits;
    }
}
