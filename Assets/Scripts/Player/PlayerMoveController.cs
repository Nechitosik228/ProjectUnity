using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Vector2 _moveInput;
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

    }

    #endregion
}
