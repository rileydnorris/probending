using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationHandler : MonoBehaviour
{
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void SetPlayerDirection(bool isRight)
    {
        gameObject.transform.rotation = isRight ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
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
}
