using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public EventBus _eventBus { get; private set; }
    public static GameManager Instance;
    public GameState _currentGameState { get; private set; } = GameState.SYSTEM;

    [SerializeField] private MyInputManager _inputManager;
    [SerializeField] private UIManager _UIManager;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
        Instance = this;

        _eventBus = new EventBus();
        _inputManager.Initialize(_eventBus);
        _UIManager.Initialize(_eventBus);
        _eventBus.OnGameChangeRequest += ChangeGameState;

        ChangeGameState(GameState.MENU);
    }
    private void ChangeGameState(GameState newState)
    {
        if (_currentGameState == newState) return;

        switch (newState)
        {
            case GameState.GAME:
                OnChangeScene(Scene.GAME);
                break;
            case GameState.MENU:
                OnChangeScene(Scene.MENU);
                break;
            case GameState.LOADING:
                OnChangeScene(Scene.LOADING);
                break;

        }

        _currentGameState = newState;
        _eventBus.OnGameChangeRequestTrigger(newState);
    }
    private void OnChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
public enum GameState
{
    SYSTEM = 0,
    GAME = 1,
    MENU = 2,
    LOADING = 3
}
