using UnityEngine;

public class UIManager : MonoBehaviour
{
    public EventBus _eventBus { get; private set; }
    public UIState _currentUIState { get; private set; } = UIState.SYSTEM;

    private ButtonType _type;

    public void Initialize(EventBus eventBus)
    {
        _eventBus = eventBus;
        _eventBus.OnGameStateChanged += OnGameStateChanged;
        _eventBus.OnButtonType += GetButtonType;
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
        _eventBus.OnUIStateChangeTrigger(newState);
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

    private void GetButtonType(ButtonType type)
    {
        GameState state = GameManager.Instance._currentGameState;
        switch (type)
        {
            case ButtonType.GAME:
                if (state == GameState.MENU)
                {
                    _eventBus.OnGameChangeRequestTrigger(GameState.GAME);
                }
                break;
            case ButtonType.MENU:
                break;
            case ButtonType.SETTINGS:
                UIChangeRequest(UIState.SETTINGS);
                break;
        }
    }
}


public enum UIState
{
    SYSTEM = 0,
    GAME = 1,
    MENU = 2,
    LOADING = 3,
    SETTINGS = 4,
}