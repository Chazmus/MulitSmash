using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviourPun
{
    private Rigidbody2D rigidBody;

    [SerializeField]
    private int speed;
    private PlayerInput playerInput;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    public void OnMove(InputValue value)
    {
        var val = value.Get<Vector2>();
        rigidBody.AddForce(val * 10);
        Debug.Log(val);
    }

    private void Update()
    {
        playerInput.actions
    }
}
