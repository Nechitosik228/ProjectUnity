using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class MyInputManager : MonoBehaviour
{
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public void OnSpaceCallback(CallbackContext input)
    {
        _eventBus.OnSpaceTrigger();
    }

    public void OnMoveCallback(CallbackContext input)
    {
        Vector2 move = input.ReadValue<Vector2>();
        _eventBus.TriggerMove(move);
    }

    public void OnShiftCallback(CallbackContext input)
    {
        if (input.performed)
        {
            _eventBus.OnShiftTrigger(true);
            Debug.Log("Shift Pressed");
        }
        else if (input.canceled)
        {
            _eventBus.OnShiftTrigger(false);
            Debug.Log("Shift Released");
        }
    }

    public void OnAttackCallback(CallbackContext input)
    {
        if (input.started)
        {
            _eventBus.OnAttackTrigger(true);
        }
        else if (input.canceled)
        {
            _eventBus.OnAttackTrigger(false);
        }
    }

    public void OnLook(CallbackContext input)
    {
        Vector2 look = input.ReadValue<Vector2>();
        _eventBus.OnLookTrigger(look);
    }
}
