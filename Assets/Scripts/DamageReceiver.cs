using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    public float maxDamage;
    public float maxKnockbackForce;

    [SerializeField]
    private float currentDamage = 0;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void AddDamage(float damage, bool doKnockback = true, Vector2? direction = null)
    {
        // TODO: Disable movement

        currentDamage += damage;
        if (currentDamage > maxDamage)
            currentDamage = maxDamage;

        if (doKnockback && direction != null)
        {
            float knockbackForce = (currentDamage / maxDamage) * maxKnockbackForce;
            _rb.AddForce((direction ?? Vector2.right) * knockbackForce, ForceMode2D.Impulse);
        }

        // If object is animated, apply hurt animation
        AnimationHandler anim = GetComponent<AnimationHandler>();
        if (anim)
        {
            anim.SetHurt();
        }
    }
}
