using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)),
RequireComponent(typeof(Animator))]
public class Attack : MonoBehaviour
{
    public float launchForce;
    public float damage;

    private Rigidbody2D _rb;
    private Animator _anim;
    private bool _destroyOnCollision = false;
    private string _sender;
    private Vector2 _direction;

    protected virtual void OnAwake() { }

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        OnAwake();
    }

    public void Launch(Vector2 direction, GameObject sendingObj)
    {
        _direction = direction;
        _sender = sendingObj.name;

        if (_direction == Vector2.zero)
            _direction = Vector2.right;

        _rb.AddForce(_direction * launchForce, ForceMode2D.Impulse);
    }

    protected IEnumerator SetTimedDestruction(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy();
    }

    protected void SetCollisionDestruction()
    {
        _destroyOnCollision = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (_destroyOnCollision && (other.gameObject.layer == 6 || other.gameObject.layer == 3) && other.gameObject.name != _sender)
        {
            DamageReceiver collidedObj = other.gameObject.GetComponent<DamageReceiver>();
            Destroy(collidedObj);
        }
    }

    void Destroy(DamageReceiver collidedObject = null)
    {
        _anim.SetTrigger(Keys.DoComplete);
        if (collidedObject)
            collidedObject.AddDamage(damage, true, _direction);
    }
}
