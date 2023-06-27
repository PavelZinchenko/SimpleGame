using UnityEngine;

public class PlayerAnimation : MonoBehaviour, ICharacterAnimation
{
    [SerializeField] private Animator _animator;

    [Range(0f, 1f)][SerializeField] private float _speedThreshold = 0.1f;

    private bool _rightToLeft;

    private readonly int _speed = Animator.StringToHash("speed");
    private readonly int _jumpSpeed = Animator.StringToHash("jumpSpeed");
    private readonly int _grounded = Animator.StringToHash("grounded");

    public void Walk(Vector2 velocityNormalized)
    {
        transform.UpdateDirection(velocityNormalized.x, _speedThreshold, ref _rightToLeft);
        _animator.SetFloat(_speed, velocityNormalized.magnitude);
    }

    public void Jump(float speed, bool grounded)
    {
        _animator.SetFloat(_jumpSpeed, speed);
        _animator.SetBool(_grounded, grounded);
    }
}
