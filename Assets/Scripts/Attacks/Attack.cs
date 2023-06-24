using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)),
RequireComponent(typeof(Animator))]
public class Attack : MonoBehaviour
{
    public float launchForce;
    private Rigidbody2D _rb;
    private Animator _anim;

    protected virtual void OnAwake() { }

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        OnAwake();
    }

    public void Launch(Vector2 direction)
    {
        if (direction == Vector2.zero)
            direction = Vector2.right;

        _rb.AddForce(direction * launchForce, ForceMode2D.Impulse);
    }

    protected IEnumerator SetTimedDestruction(float duration)
    {
        yield return new WaitForSeconds(duration);
        _anim.SetTrigger(Keys.DoComplete);
    }

    protected void SetCollisionDestruction(Animation anim)
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // TODO: Add player collision

        if (other.gameObject.layer == 6)
        {
            _anim.SetTrigger(Keys.DoComplete);
        }
    }
}
