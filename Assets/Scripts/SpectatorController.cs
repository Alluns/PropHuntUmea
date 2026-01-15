using UnityEngine;
using UnityEngine.InputSystem;

public class SpectatorController : PlayerController
{
    private Vector2 move;
    private Vector2 look;

    private Vector3 currentRot = Vector3.zero;

    protected override void Start()
    {
        base.Start();

        currentRot = transform.rotation.eulerAngles;
    }

    public override void PlayerUpdate()
    {
        camera.transform.position = transform.position;
        camera.transform.forward = transform.forward;
        
        Vector3 translation = Vector3.zero;
        translation += camera.transform.forward * move.y;
        translation += camera.transform.right * move.x;
        translation.Normalize();
        
        transform.Translate(translation * (10.0f * Time.deltaTime), Space.World);

        Vector3 rotation = Vector3.zero;
        rotation += Vector3.up * look.x;
        rotation += Vector3.right * -look.y;
        rotation *= Time.deltaTime * 90.0f;

        // Vector3 currentRot = transform.rotation.eulerAngles;
        currentRot += rotation;
        currentRot.x = Mathf.Clamp(currentRot.x, -88.0f, 88.0f);
        transform.rotation = Quaternion.Euler(currentRot);
        
    }

    private void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    private void OnLook(InputValue value)
    {
        look = value.Get<Vector2>();
    }
}
