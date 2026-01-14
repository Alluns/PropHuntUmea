using System;
using Unity.Netcode;
using UnityEngine;

public abstract class PlayerController : NetworkBehaviour
{
    protected Camera camera;
    
    protected void Start()
    {
        camera = Camera.main;
    }

    public abstract void PlayerUpdate();
}
