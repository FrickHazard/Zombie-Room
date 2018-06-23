using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Exit : MonoBehaviour {
    public bool Locked;
    public Exit CorrespondingExit;
    public Room room;
    public new Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    public void Initialize(Vector2 location, Room room)
    {
        this.transform.position = location;
    }

    public void AddCorrespondingExit(Exit exit)
    {
        CorrespondingExit = exit;
    }
}
