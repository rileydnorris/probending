using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ObjectStatus))]
[RequireComponent(typeof(AnimationHandler))]
public class MovementController : MonoBehaviour
{
    public float normalSpeed = 6.0f;
    public float slowdownSpeed = 2.0f;
    private Vector2 _movementVector;
    private ObjectStatus _status;
    private Rigidbody2D _rigidBody;
    private AnimationHandler _anim;

    private float speed
    {
        get
        {
            // Return slower speed if user is attacking
            return _status.isAttacking ? slowdownSpeed : normalSpeed;
        }
    }

    public bool isMoving
    {
        get
        {
            return Mathf.Abs(_movementVector.x) > 0.1 || Mathf.Abs(_movementVector.y) > 0.1;
        }
    }

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _status = GetComponent<ObjectStatus>();
        _anim = GetComponent<AnimationHandler>();
    }

    void Update()
    {
        RotatePlayer();
        if (CanMove())
        {
            _rigidBody.velocity = _movementVector * speed;
            HandleAnimation();
        }
    }

    bool CanMove()
    {
        return !_status.isAI && _status.currentDashState != DashState.Dashing && _status.currentKnockbackState != KnockbackState.InKnockback;
    }

    void HandleAnimation()
    {
        _anim.SetRunning(isMoving);
    }

    void RotatePlayer()
    {
        if (Mathf.Abs(_movementVector.x) > 0.1)
        {
            _anim.SetPlayerDirection(_movementVector.x > 0);
        }
    }

    public void OnMove(Vector2 movement)
    {
        _movementVector = movement;
        _status.movementVector = movement;
    }
}
