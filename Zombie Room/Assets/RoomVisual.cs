using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomVisual : MonoBehaviour {
    public Exit exitPrefab;
    public List<Exit> Exits = new List<Exit>();

    private void Awake()
    {
        GameState.RegisterMainRoom(this);
    }

    public void SetFromData(RoomData data)
    {
        foreach (var exit in Exits)
        {
            Destroy(exit.gameObject);
        }
        Exits.Clear();
        foreach (var exitData in data.Exits)
        {
            var exit = Instantiate(exitPrefab);
            exit.SetFromData(exitData);
            exit.transform.parent = this.transform;
            Exits.Add(exit);
        }

    }

    public void LockExits()
    {
        foreach (Exit exit in Exits)
        {
            exit.Locked = true;
        }
    }
}
