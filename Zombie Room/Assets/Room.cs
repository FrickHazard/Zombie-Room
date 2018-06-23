using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public List<Exit> exits = new List<Exit>();

    public void LockExits()
    {
        foreach (Exit exit in exits)
        {
            exit.Locked = true;
        }
    }
}
