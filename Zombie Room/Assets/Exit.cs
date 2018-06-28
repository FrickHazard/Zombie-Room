using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Exit : MonoBehaviour {
    public bool Locked;
    private ExitData data; 
    public new Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    public void SetFromData(ExitData data)
    {
        this.transform.position = data.Location;
        this.data = data;
    }

    public void OnClick(Vector2 mousePosition)
    {
        if (collider.OverlapPoint(mousePosition))
        {
           if(!Locked) GameState.StartPlayerMovement(this.transform.position, data);
        }
    }

}
