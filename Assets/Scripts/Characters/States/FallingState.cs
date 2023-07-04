using UnityEngine;
using UnityEngine.Events;

namespace Characters.States
{
    public class FallingState : CharacterState
    {
        [SerializeField] private float _initialSpeed = 0;
        [SerializeField] private float _gravity = 20;

        [SerializeField] private Transform _body;
        [SerializeField] private Collider2D _bodyCollider;
        [SerializeField] private AnimationController _animation;

        [SerializeField] private CharacterState _walkTransition;
        [SerializeField] private CharacterState _dieTransition;

        [SerializeField] private UnityEvent _landed = new();

        private float _altitude;
        private float _speed;

        private const float _groundLevel = 0f;
        private const float _groundBottomLevel = -0.1f;
        private const float _bottomAltitude = -20;

        public float InitialSpeed 
        {
            get => _initialSpeed; 
            set => _initialSpeed = value; 
        }

        private void Update()
        {
            var aboveGround = _altitude >= _groundBottomLevel;
            _speed -= _gravity * Time.deltaTime;
            _altitude += _speed * Time.deltaTime;

            if (aboveGround && _altitude <= _groundLevel && Context.Grounded)
            {
                _altitude = _groundLevel;
                _speed = 0;
                _landed.Invoke();
                _animation.SetGrounded(true);
                Transition = _walkTransition;
            }
            else if (_altitude < _bottomAltitude)
            {
                Transition = _dieTransition;
            }

            _animation.Jump(_speed);
            ApplyAltitude();
        }

        protected override void OnEnter() 
        {
            _altitude = _body.localPosition.y;
            _speed = _initialSpeed;
            _initialSpeed = 0f;

            _animation.SetGrounded(false);

            if (_bodyCollider) 
                _bodyCollider.enabled = false;
        }

        protected override void OnExit() 
        {
            if (_bodyCollider) 
                _bodyCollider.enabled = true;
        }

        private void ApplyAltitude()
        {
            var position = _body.localPosition;
            position.y = _altitude;
            _body.localPosition = position;
        }
    }
}
