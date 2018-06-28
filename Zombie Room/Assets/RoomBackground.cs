using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RoomBackground : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        GameState.RegisterRoomBackground(this);
    }

    public void SetFromData(RoomData roomData)
    {
        if (!spriteRenderer.sprite) throw new NullReferenceException("Sprite in renderer was null");
        this.transform.localScale = new Vector3(1, 1, 1);
        var xSize = roomData.Width / spriteRenderer.bounds.size.x;
        var ySize = roomData.Height / spriteRenderer.bounds.size.y;
        this.transform.localScale = new Vector3(xSize, ySize, 1);
    }
}
