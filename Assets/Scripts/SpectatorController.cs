using UnityEngine;
using UnityEngine.InputSystem;

public class SpectatorController : PlayerController
{
    private Vector2 move;
    public override void PlayerUpdate()
    {
        // camera.transform.position += Vector3.right * (Time.deltaTime * 2.0f);
        // print("moving");
        transform.Translate(move * Time.deltaTime * 2.0f);
    }

    private void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }
}
