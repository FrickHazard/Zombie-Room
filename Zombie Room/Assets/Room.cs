using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public RoomBackground backgroundPrefab;
    private RoomBackground background;
    public List<Exit> exits = new List<Exit>();
    public int Width = 0;
    public int Height = 0;

    private void Awake()
    {
        background = Instantiate(backgroundPrefab);
    }

    public void Initialize(int size)
    {
        Width = size;
        Height = size;
        background.Initialize(size, Random.ColorHSV());
    }


    public void LockExits()
    {
        foreach (Exit exit in exits)
        {
            exit.Locked = true;
        }
    }
}
