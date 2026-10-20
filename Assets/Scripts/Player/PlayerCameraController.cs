using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private Transform _cameraPivot;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _maxCameraYaw = 50f;
    [SerializeField] private float _maxCameraPitch = 60f;
    [SerializeField] private float _returnSpeed = 3f;

    private float _rotationX;
    private float _rotationY;
    private float _currentRotationX;
    private float _currentRotationY;

    private void Start()
    {
        Vector3 angles = _cameraPivot.localEulerAngles;
        _rotationX = angles.x;
        _rotationY = angles.y;
    }

    public void RotateCamera(Vector2 input)
    {
        Debug.Log(input);
        float mouseX = input.y * _rotationSpeed;
        float mouseY = input.x * _rotationSpeed;

        _currentRotationX = _cameraPivot.rotation.x + mouseX;
        _currentRotationY = _cameraPivot.rotation.y + mouseY;
        Debug.Log(_currentRotationX);
        _currentRotationX = Mathf.Clamp(_currentRotationX, -_maxCameraPitch, _maxCameraPitch);

        _cameraPivot.localRotation = Quaternion.Euler(_currentRotationX, _currentRotationY, 0);
    }
}
