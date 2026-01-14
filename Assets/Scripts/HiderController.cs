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

    private void OnLook(InputValue value)
    {
        const float distance = 4.0f;
        
        //camera.transform.SetLocalPositionAndRotation(-distance, );
        
        Vector3 direction = new Vector3(-value.Get<Vector2>().y, value.Get<Vector2>().x, 0);

        //camera.transform.Rotate( direction * 15f * Time.deltaTime, Space.World);
    }
}