using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Animator))]
    public class AnimationController : MonoBehaviour
    {
        [Range(0f, 1f)] [SerializeField] private float _speedThreshold = 0.1f;

        private Animator _animator;
        private bool _rightToLeft;

        private readonly int _speed = Animator.StringToHash("speed");
        private readonly int _jumpSpeed = Animator.StringToHash("jumpSpeed");
        private readonly int _grounded = Animator.StringToHash("grounded");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Walk(Vector2 velocityNormalized)
        {
            transform.UpdateDirection(velocityNormalized.x, _speedThreshold, ref _rightToLeft);
            _animator.SetFloat(_speed, velocityNormalized.magnitude);
        }

        public void Jump(float speed)
        {
            _animator.SetFloat(_jumpSpeed, speed);
        }

        public void SetGrounded(bool grounded)
        {
            _animator.SetBool(_grounded, grounded);
        }
    }
}
