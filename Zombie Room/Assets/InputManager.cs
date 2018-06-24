using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    void Awake()
    {
        GameState.RegisterInputManager(this);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var room = GameState.GetActiveRoom();
            foreach (var exit in room.Exits)
            {
                exit.OnClick(mousePosition);
            }
        }
    }
}
