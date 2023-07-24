using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectStatus))]
public class CombatController : MonoBehaviour
{
    public GameObject fire_quick;

    private ObjectStatus _status;
    private AnimationHandler _anim;

    void Start()
    {
        _status = GetComponent<ObjectStatus>();
        _anim = GetComponent<AnimationHandler>();
    }

    void Update()
    {

    }

    public void OnQuickAttack()
    {
        Utility.LaunchAttack(gameObject, fire_quick, _status.movementVector);
        _anim.SetQuickAttacking();
        _status.isAttacking = true;
    }

    public void OnQuickAttackEnd()
    {
        _status.isAttacking = false;
    }

    public void OnStrongAttack()
    {

    }

    public void OnStrongAttackEnd()
    {

    }
}
