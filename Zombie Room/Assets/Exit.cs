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

    public void SetFromData(ExitData data)
    {
        this.transform.position = data.Location;
    }

    public void AddCorrespondingExit(Exit exit)
    {
        CorrespondingExit = exit;
    }

    public void OnClick(Vector2 mousePosition)
    {
        if (collider.OverlapPoint(mousePosition))
        {

        }
    }

}
