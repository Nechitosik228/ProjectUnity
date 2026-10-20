using System.Linq;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckDistance = 0.1f;
    [SerializeField] private Transform _groundCheck;

    public bool isGrounded()
    {
        return Physics.OverlapSphere(_groundCheck.position, _groundCheckDistance, _groundLayer).Count() > 0;
    }
}
