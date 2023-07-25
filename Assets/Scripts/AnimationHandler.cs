using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationHandler : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _spriteRen;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _spriteRen = GetComponent<SpriteRenderer>();
    }

    public void SetPlayerDirection(bool isRight)
    {
        _spriteRen.flipX = !isRight;
    }

    public void SetRunning(bool isRunning)
    {
        _anim.SetBool("isRunning", isRunning);
    }

    public void SetQuickAttacking()
    {
        _anim.SetBool("isQuickAttacking", true);
    }

    public void ResetQuickAttacking()
    {
        _anim.SetBool("isQuickAttacking", false);
    }

    public void SetDashing()
    {
        _anim.SetBool("isDashing", true);
    }

    public void ResetDashing()
    {
        _anim.SetBool("isDashing", false);
    }

    public void SetHurt()
    {
        _anim.SetBool("isHurt", true);
    }

    public void ResetHurt()
    {
        _anim.SetBool("isHurt", false);
    }

    public void SetDeath()
    {
        _anim.SetBool("isDead", true);
    }

    public void ResetDeath()
    {
        _anim.SetBool("isDead", false);
    }
}
