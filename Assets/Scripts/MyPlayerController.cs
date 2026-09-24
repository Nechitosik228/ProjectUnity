using UnityEngine;

public class MyPlayerController : MonoBehaviour
{
    private EventBus _eventBus;

    private void OnEnable()
    {
        _eventBus = GameManager.Instance._eventBus;
        _eventBus.OnMovePressed += OnMove;
    }

    private void OnDisable()
    {
        _eventBus.OnMovePressed -= OnMove;
    }

    private void OnMove(Vector2 data)
    {
        Debug.Log($"Player recieved: {data}");
    }
}
