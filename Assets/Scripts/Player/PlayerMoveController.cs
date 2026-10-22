using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Vector2 _moveInput;
    private Vector3 _moveVector;
    private bool _shiftInput;
    private bool _ctrlInput;
    private bool _isGrounded;
    private bool _isJumpQeued = false;
    private PlayerAnimationController _animationController;
    private float _lookInput;

    [Header("Walking Logic")]

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rotationSpeed;

    private float _currentRunSpeed;
    private WalkState _currentWalkingState = 0;

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

    public void GetLookInput(Vector2 input)
    {
        if (input.sqrMagnitude < 0.1f) return;
        _lookInput = input.x;
    }

    public void GetShiftInput(bool isPressed)
    {
        _shiftInput = isPressed;
    }

    public void GetSpaceInput()
    {
        if (!_isGrounded) return;
        // _rb.AddForce(new Vector3(0f, _jumpForce, 0f), ForceMode.Impulse);
        _isJumpQeued = true;
        // _rb.linearVelocity = new Vector3(0f, _jumpForce, 0f);
    }

    public void GetCtrlInput(bool isPressed)
    {

    }

    public void GetGroundInfo(bool t)
    {
        _isGrounded = t;
        Debug.Log(t);
    }

    #endregion

    #region Move

    private void Move()
    {
        float moveX = _moveInput.x * transform.right.x * _currentRunSpeed * Time.fixedDeltaTime;
        float moveZ = _moveInput.y * transform.forward.z * _currentRunSpeed * Time.fixedDeltaTime;
        float moveY = _rb.linearVelocity.y;
        if (_isJumpQeued && _isGrounded)
        {
            moveY = _jumpForce;
            _isJumpQeued = false;
        }
        Vector3 linearVelocity = new Vector3(moveX, moveY, moveZ);
        _rb.linearVelocity = linearVelocity;
        // _moveVector = transform.right * _moveInput.x + transform.forward * _moveInput.y;
        // _moveVector *= _currentRunSpeed * Time.fixedDeltaTime;
        // _rb.MovePosition(_moveVector + _rb.position);
    }

    private void RotatePlayer()
    {
        Vector3 newRotation = new Vector3(transform.rotation.x, transform.rotation.y + (_lookInput * _rotationSpeed), transform.rotation.z) * Time.deltaTime;
        transform.Rotate(newRotation);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private float GetMoveSpeed(WalkState state)
    {
        float newSpeed = 0;
        switch (state)
        {
            case WalkState.Standing:
                break;
            case WalkState.Walk:
                newSpeed = _walkSpeed;
                break;
            case WalkState.SideWalking:
                newSpeed = _walkSpeed / 2;
                break;
            case WalkState.BackWalking:
                newSpeed = _walkSpeed / 2;
                break;
        }
        _currentWalkingState = state;
        return newSpeed;
    }

    private void CalculateSpeed()
    {
        bool isMoving = _moveInput.sqrMagnitude > 0.1f;

        if (!isMoving)
        {
            _currentRunSpeed = 0;
            return;
        }

        float newSpeed = 0;
        if (_moveInput.y < 0)
        {
            newSpeed = GetMoveSpeed(WalkState.BackWalking);
        }
        else if (_moveInput.y > 0)
        {
            newSpeed = GetMoveSpeed(WalkState.Walk);
        }
        else if (_moveInput.y == 0 && _moveInput.x != 0)
        {
            newSpeed = GetMoveSpeed(WalkState.SideWalking);
        }

        if (_shiftInput)
        {
            newSpeed *= _runSpeed / _walkSpeed;
        }
        _currentRunSpeed = newSpeed;
    }

    #endregion

    #region UnityLogic

    private void Update()
    {
        CalculateSpeed();
        UpdateAnimation();
        RotatePlayer();
    }

    #endregion

    #region Update Animation

    private void UpdateAnimation()
    {
        _animationController.RunningAnim(_currentRunSpeed, _moveInput);
    }

    #endregion
}


public enum WalkState
{
    Standing = 0,
    Walk = 1,
    SideWalking = 2,
    BackWalking = 3,
    Running = 4
}
