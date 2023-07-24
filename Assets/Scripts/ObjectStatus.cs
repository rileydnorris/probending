using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatus : MonoBehaviour
{
    public DashState currentDashState { get; set; } = DashState.Ready;
    public KnockbackState currentKnockbackState { get; set; } = KnockbackState.NotInKnockback;
    public Vector2 movementVector { get; set; } = Vector2.zero;
    public bool isAI = false;

    void Start()
    {

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
