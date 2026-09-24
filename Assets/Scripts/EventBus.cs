using System;
using UnityEngine;

public class EventBus
{
    public event Action<Vector2> OnMovePressed;

    public void TriggerMove(Vector2 data)
    {
        OnMovePressed?.Invoke(data);
    }
}
