using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectStatus))]
public class CombatController : MonoBehaviour
{
    public GameObject fire_quick;

    private ObjectStatus _status;

    void Start()
    {
        _status = GetComponent<ObjectStatus>();
    }

    void Update()
    {

    }

    public void OnQuickAttack()
    {
        Utility.LaunchAttack(gameObject, fire_quick, _status.movementVector);
    }

    public void OnStrongAttack()
    {

    }
}
