using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIButton : MonoBehaviour
{
    [SerializeField] protected Button _button;
    [SerializeField] private TMP_Text _textField;
    [SerializeField] protected ButtonType _type;

    protected EventBus _eventBus;

    private void Awake()
    {
        Initialize();
    }
    protected virtual void Initialize()
    {
        _eventBus = GameManager.Instance._eventBus;
        _button.onClick.AddListener(SendPayLoad);
        SetText();
    }
    protected virtual void DeInitialize()
    {
        _button.onClick.RemoveListener(SendPayLoad);
    }
    private void OnDestroy()
    {
        DeInitialize();
    }
    private void SetText()
    {
        _textField.text = _type.ToString();
    }
    protected virtual void SendPayLoad()
    {

    }
}


public enum ButtonType
{
    DEFAULT = 0,
    MENU = 1,
    GAME = 2,
    SETTINGS = 3,
}