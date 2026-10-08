using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Vector2 _moveInput;
    private Vector3 _moveVector;
    private bool _shiftInput;
    private bool _ctrlInput;
    private PlayerAnimationController _animationController;

    [Header("Walking Logic")]

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;

    private float _currentRunSpeed;

    public void Initialize(PlayerAnimationController a)
    {
        _animationController = a;
    }

    #region Get Input

    public void GetMoveInput(Vector2 input)
    {
        _moveInput = input;
        _moveInput.Normalize();
    }

    public void GetShiftInput(bool isPressed)
    {

    }

    public void GetSpaceInput()
    {

    }

    public void GetCtrlInput(bool isPressed)
    {

    }

    #endregion

    #region Move

    private void Move()
    {
        bool isMoving = _moveInput.sqrMagnitude > 0.1f;
        if (isMoving && !_shiftInput)
        {
            _currentRunSpeed = _walkSpeed;
        }
        else if (isMoving && _shiftInput)
        {
            _currentRunSpeed = _runSpeed;
        }
        else
        {
            _currentRunSpeed = 0;
        }
        // float currentSpeed = _isRunning ? _runSpeed : _walkSpeed;
        _moveVector = transform.right * _moveInput.x + transform.forward * _moveInput.y;
        _moveVector *= _walkSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(_moveVector + _rb.position);
    }

    #endregion

    #region UnityLogic

    private void Update()
    {
        Move();
        UpdateAnimation();
    }

    #endregion

    #region Update Animation

    private void UpdateAnimation()
    {
        _animationController.RunningAnim(_currentRunSpeed, _moveInput);
    }

    #endregion
}
