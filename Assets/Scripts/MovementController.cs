using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ObjectStatus))]
public class MovementController : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 _movementVector;
    private ObjectStatus _status;
    private Rigidbody2D _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _status = GetComponent<ObjectStatus>();
    }

    void Update()
    {
        if (CanMove())
        {
            _rigidBody.velocity = _movementVector * speed;
        }
    }

    bool CanMove()
    {
        return !(_status.DashState == DashState.Dashing);
    }

    public void OnMove(Vector2 movement)
    {
        _movementVector = movement;
        _status.MovementVector = movement;
    }
}
