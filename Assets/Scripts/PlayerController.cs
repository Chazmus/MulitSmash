using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviourPun
{
    private Rigidbody2D rigidBody;

    [SerializeField] private int speed = 1;
    [SerializeField] private int maxSpeed = 5;

    private PlayerInput playerInput;
    private float horizontalMove;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        var spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.color = Random.ColorHSV();
    }

    public void OnMove(InputValue value)
    {
        horizontalMove = value.Get<Vector2>().x;
    }

    private void Update()
    {
        // Add current horizontal movement to rigidbody velocity
        var velocity = rigidBody.velocity;
        velocity += new Vector2(horizontalMove * speed, 0);

        // Make sure the absolute value of horizontal velocity is less than maxSpeed
        if (Mathf.Abs(velocity.x) > maxSpeed)
        {
            velocity.x = velocity.x > 0 ? maxSpeed : -maxSpeed;
        }

        rigidBody.velocity = velocity;
    }
}