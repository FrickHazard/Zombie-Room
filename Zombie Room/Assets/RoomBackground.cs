using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RoomBackground : MonoBehaviour {

    public void Set(int width, int height, Color color)
    {
        var renderer = GetComponent<SpriteRenderer>();
        var sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f));
        renderer.sprite = sprite;
        renderer.material.color = color;
        var xSize = width / renderer.bounds.size.x;
        var ySize = height / renderer.bounds.size.y;
        this.transform.localScale = new Vector3(xSize, ySize, 1);
    }
}
