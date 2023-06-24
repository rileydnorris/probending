using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMapping : MonoBehaviour
{
    private MovementController _movementController;
    private DashController _dashController;
    private CombatController _combatController;

    void Start()
    {
        _movementController = GetComponent<MovementController>();
        _dashController = GetComponent<DashController>();
        _combatController = GetComponent<CombatController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementController.OnMove(context.ReadValue<Vector2>());
    }

    public void OnQuickAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _combatController.OnQuickAttack();
        }
    }

    public void OnStrongAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _dashController.OnDash();
        }
    }
}
