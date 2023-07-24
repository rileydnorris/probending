using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectStatus))]
public class DashController : MonoBehaviour
{
    private Rigidbody2D rb;
    private ObjectStatus _status;
    private AnimationHandler _anim;

    public float dashDuration = 0.5f;
    public float dashCooldown = 3.0f;
    public float dashMultiplier = 5.0f;

    private void Start()
    {
        _status = GetComponent<ObjectStatus>();
        _anim = GetComponent<AnimationHandler>();
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator PerformDash()
    {
        _status.currentDashState = DashState.Dashing;
        rb.velocity = new Vector2(rb.velocity.x * dashMultiplier, rb.velocity.y * dashMultiplier);

        yield return new WaitForSeconds(dashDuration);

        _status.currentDashState = DashState.Cooldown;
    }

    IEnumerator StartDashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        _status.currentDashState = DashState.Ready;
    }

    public void OnDash()
    {
        if (_status.currentDashState == DashState.Ready)
        {
            _anim.SetDashing();
            StartCoroutine(PerformDash());
            StartCoroutine(StartDashCooldown());
        }
    }
}
