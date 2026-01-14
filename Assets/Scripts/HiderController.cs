using UnityEngine;
using UnityEngine.InputSystem;

public class HiderController : PlayerController
{
    private Vector2 move;
    private const float Speed = 3.0f;
    
    public override void PlayerUpdate()
    {
        transform.Translate(new Vector3(move.x, 0 ,move.y) * (Time.deltaTime * Speed));
    }

    private void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }
}
