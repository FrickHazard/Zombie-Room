using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public Room roomPrefab;
    public Exit exitPrefab;

    private int maxSize = 5;
    private int minSize = 2;

    public void BuildRootRoom()
    {
        int size = Random.Range(minSize, maxSize);
        var room = Instantiate(roomPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        room.Initialize(size);
        var exit1 = Instantiate(exitPrefab);
        exit1.Initialize(new Vector2((float)size / 2, 0), room);
        var exit2 = Instantiate(exitPrefab);
        exit2.Initialize(new Vector2(0, (float)size / 2), room);
        var exit3 = Instantiate(exitPrefab);
        exit3.Initialize(new Vector2(-(float)size / 2, 0), room);
        var exit4 = Instantiate(exitPrefab);
        exit4.Initialize(new Vector2(0, -(float)size / 2), room);
        GameState.FocusCameraToRoom(room);
    }


    private void Start()
    {
        BuildRootRoom();
    }
}
