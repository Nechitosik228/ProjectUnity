using System;
using UnityEngine;

public class EventBus
{
    public event Action<Vector2> OnMovePressed;
    public event Action OnSpacePressed;
    public event Action<bool> OnAttackPressed;
    public event Action<bool> OnShiftPressed;
    public event Action<Vector2> OnLookPressed;
    public event Action<GameState> OnGameStateChanged;
    public event Action<GameState> OnGameChangeRequest;
    public event Action<UIState> OnUIStateChanged;
    public event Action<UIState> OnUIChangeRequest;

    public void TriggerMove(Vector2 data)
    {
        OnMovePressed?.Invoke(data);
    }

    public void OnSpaceTrigger()
    {
        OnSpacePressed?.Invoke();
    }

    public void OnShiftTrigger(bool isPressed)
    {
        OnShiftPressed?.Invoke(isPressed);
    }

    public void OnAttackTrigger(bool isPressed)
    {
        OnAttackPressed?.Invoke(isPressed);
    }

    public void OnLookTrigger(Vector2 data)
    {
        OnLookPressed?.Invoke(data);
    }

    public void OnGameStateChangeTrigger(GameState newState)
    {
        OnGameStateChanged.Invoke(newState);
    }

    public void OnGameChangeRequestTrigger(GameState newState)
    {
        OnGameChangeRequest.Invoke(newState);
    }

    public void OnUIStateChangeTrigger(UIState newState)
    {
        OnUIStateChanged.Invoke(newState);
    }

    public void OnUIChangeRequestTrigger(UIState newState)
    {
        OnUIChangeRequest.Invoke(newState);
    }
}
