using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public EventBus _eventBus { get; private set; }
    public static GameManager _Instance;
    public GameState _currentGameState { get; private set; } = GameState.SYSTEM;

    [SerializeField] private MyInputManager _inputManager;

    private void Awake()
    {
        if (_Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
        _Instance = this;

        _eventBus = new EventBus();
        _inputManager.Initialize(_eventBus);

        OnChangeScene(Scene.GAME);
    }
    private void ChangeGameState(GameState newState)
    {
        if (_currentGameState == newState) return;

        _currentGameState = newState;
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
