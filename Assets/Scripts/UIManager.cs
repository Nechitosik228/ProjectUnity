using UnityEngine;

public class UIManager : MonoBehaviour
{
    public EventBus _eventBus { get; private set; }
    public UIState _currentUIState { get; private set; } = UIState.SYSTEM;

    public void Initialize(EventBus eventBus)
    {
        _eventBus = eventBus;
        _eventBus.OnUIChangeRequest += UIChangeRequest;
        _eventBus.OnGameStateChanged += OnGameStateChanged;
    }

    private void UIChangeRequest(UIState newState)
    {
        if (_currentUIState == newState) return;
        switch (newState)
        {
            case UIState.GAME:
                break;
            case UIState.MENU:
                break;
            case UIState.LOADING:
                break;
        }

        _currentUIState = newState;
        _eventBus.OnUIChangeRequestTrigger(newState);
    }

    private void OnGameStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.GAME:
                UIChangeRequest(UIState.GAME);
                break;
            case GameState.MENU:
                UIChangeRequest(UIState.MENU);
                break;
            case GameState.LOADING:
                UIChangeRequest(UIState.LOADING);
                break;
        }
    }
}


public enum UIState
{
    SYSTEM = 0,
    GAME = 1,
    MENU = 2,
    LOADING = 3
}