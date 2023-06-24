using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatus : MonoBehaviour
{
    public DashState DashState { get; set; } = DashState.Ready;
    public Vector2 MovementVector { get; set; } = Vector2.zero;

    void Start()
    {

    }
}
