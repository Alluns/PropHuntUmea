using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerController : NetworkBehaviour
{
    protected Camera camera;
    public PlayerInput Input { get; private set; }
    
    protected virtual void Start()
    {        
        if (IsClient)
            OnClientInit();
        else


            camera = Camera.main;
    }

    protected virtual void OnClientInit() => Input = GetComponent<PlayerInput>();
    protected virtual void OnHostInit() { }

    public abstract void PlayerUpdate();
}
