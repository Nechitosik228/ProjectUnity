using UnityEngine;

public class MyPlayerController : MonoBehaviour
{
    private EventBus _eventBus;
    private bool _isDead;

    [SerializeField] private PlayerAnimationController _animationController;
    [SerializeField] private PlayerCameraController _cameraController;
    [SerializeField] private PlayerMoveController _moveController;
    [SerializeField] private PlayerShootController _shootController;
    [SerializeField] private GroundDetector _groundDetector;


    private void OnEnable()
    {
        _eventBus = GameManager._Instance._eventBus;

        _moveController.Initialize(_animationController);

        _eventBus.OnMovePressed += OnMoveInput;
        _eventBus.OnAttackPressed += OnAttackInput;
        _eventBus.OnShiftPressed += OnShiftInput;
        _eventBus.OnLookPressed += OnLookInput;
        _eventBus.OnSpacePressed += OnSpaceInput;
    }

    private void OnDisable()
    {
        _eventBus.OnMovePressed -= OnMoveInput;
        _eventBus.OnAttackPressed -= OnAttackInput;
        _eventBus.OnShiftPressed -= OnShiftInput;
        _eventBus.OnLookPressed -= OnLookInput;
        _eventBus.OnSpacePressed -= OnSpaceInput;
    }

    private void OnMoveInput(Vector2 data)
    {
        if (_isDead) return;
        _moveController.GetMoveInput(data);
    }

    private void OnLookInput(Vector2 input)
    {
        if (_isDead) return;
        _moveController.GetLookInput(input);
        _cameraController.RotateCamera(input);
    }

    private void OnAttackInput(bool isPressed)
    {
        if (_isDead) return;
    }

    private void OnShiftInput(bool isPressed)
    {
        if (_isDead) return;
        _moveController.GetShiftInput(isPressed);
    }

    private void OnSpaceInput()
    {
        if (_isDead) return;
        _moveController.GetSpaceInput();
    }

    private void FixedUpdate()
    {
        if (_isDead) return;
        bool isGrounded = _groundDetector.isGrounded();
        _moveController.GetGroundInfo(isGrounded);
    }
}
