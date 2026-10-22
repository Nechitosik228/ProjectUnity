using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private Transform _cameraPivot;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _maxCameraYaw = 50f;
    [SerializeField] private float _maxCameraPitch = 60f;
    [SerializeField] private float _returnSpeed = 3f;
    [SerializeField] private float _returnDelay = 10f;

    private float _rotationX;
    private float _rotationY;
    private float _lastActionTimer;

    private void Start()
    {
        Vector3 angles = _cameraPivot.localEulerAngles;
        _rotationX = angles.x > 180f ? angles.x - 360f : angles.x;
        _rotationY = angles.y > 180f ? angles.y - 360f : angles.y;
    }

    public void RotateCamera(Vector2 input)
    {
        if (input.sqrMagnitude < 0.1f) return;

        _rotationX -= input.y * _rotationSpeed;
        _rotationY += input.x * _rotationSpeed;

        _rotationX = Mathf.Clamp(_rotationX, -_maxCameraPitch, _maxCameraPitch);
        _rotationY = Mathf.Clamp(_rotationY, -_maxCameraYaw, _maxCameraYaw);
        _lastActionTimer = Time.time;
    }

    private void LateUpdate()
    {
        _cameraPivot.localRotation = Quaternion.Euler(_rotationX, _rotationY, 0);
    }

    private void Update()
    {
        if (Time.time - _lastActionTimer < _returnDelay) return;
        _rotationX = Mathf.MoveTowards(_rotationX, 0, _returnSpeed * Time.deltaTime * 10f);
        _rotationY = Mathf.MoveTowards(_rotationY, 0, _returnSpeed * Time.deltaTime * 10f);
    }
}
