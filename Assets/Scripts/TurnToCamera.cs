using System;
using Unity.Netcode;
using UnityEngine;

public class TurnToCamera : NetworkBehaviour
{
    private void Update()
    {
        if (!IsClient)
            return;

        transform.forward = Camera.main.transform.forward;
    }
}
