using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatus : MonoBehaviour
{
    public DashState currentDashState { get; set; } = DashState.Ready;
    public KnockbackState currentKnockbackState { get; set; } = KnockbackState.NotInKnockback;
    public Vector2 movementVector { get; set; } = Vector2.zero;
    public bool isAttacking { get; set; } = false;
    public bool isAlive { get; set; } = true;
    public bool isDisabled { get; set; } = false;
    public bool isAI = false;

    public void Reset()
    {
        currentDashState = DashState.Ready;
        currentKnockbackState = KnockbackState.NotInKnockback;
        movementVector = Vector2.zero;
        isAttacking = false;
        isAlive = true;
    }
}

public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}

public enum KnockbackState
{
    NotInKnockback,
    InKnockback,
    Impervious,
}
