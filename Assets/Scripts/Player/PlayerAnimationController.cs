using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    private const string _speed = "Speed";
    private const string _moveX = "MoveX";
    private const string _moveY = "MoveY";
    private const string _idle = "Idle";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunningAnim(float speed, Vector2 move)
    {
        _anim.SetFloat(_speed, speed);
        _anim.SetFloat(_moveY, move.y);
        _anim.SetFloat(_moveX, move.x);

    }
}
