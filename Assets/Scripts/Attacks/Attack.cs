using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attack : MonoBehaviour
{
    public float launchForce;
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction)
    {
        if (direction == Vector2.zero)
            direction = Vector2.right;

        _rb.AddForce(direction * launchForce, ForceMode2D.Impulse);
    }
}
