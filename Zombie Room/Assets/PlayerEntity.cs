using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    private bool moving = false;
    private Vector2 target;
    private float closeEnoughDistance = 0.02f;

    void Awake()
    {
        GameState.RegisterPlayerEntity(this);
    }

    private void Update()
    {
        if (moving)
        {
            var vector = (target - (Vector2)this.transform.position).normalized;
            vector *= GameState.PlayerSpeed;
            var currentDistanceToTarget = Vector2.Distance(this.transform.position, target);
            var nextPosition = (Vector2)this.transform.position + vector;
            if (currentDistanceToTarget - vector.magnitude < closeEnoughDistance)
            {
                this.transform.position = target;
                moving = false;
                GameState.OnEndPlayerMovement();
                return;
            }
            this.transform.position = nextPosition;
        }
    }

    public void SetPlayerEntityPosition(Vector2 position)
    {
        transform.position = position;
        moving = false;
    }

    public void StartMovement(Vector2 target)
    {
        this.target = target;
        moving = true;
    }
}
