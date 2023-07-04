using UnityEngine;

namespace Characters.States
{
    public class WalkingState : CharacterState
    {
        [SerializeField] private float _movementSpeed = 4;
        [SerializeField] private float _acceleration = 300;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private AnimationController _animation;

        [SerializeField] private CharacterState _jumpTransition;
        [SerializeField] private CharacterState _fallTransition;
        [SerializeField] private CharacterState _dieTransition;

        private void Update()
        {
            var velocity = _rigidbody2D.velocity;
            var desiredVelocity = Context.MovementDirection * _movementSpeed;
            _rigidbody2D.AddForce(_acceleration * Time.deltaTime * (desiredVelocity - velocity));
            _animation.Walk(velocity / _movementSpeed);

            if (Context.MustDie)
                Transition = _dieTransition;
            else if (Context.WantToJump && _jumpTransition != null)
                Transition = _jumpTransition;
            else if (!Context.Grounded && _fallTransition != null)
                Transition = _fallTransition;
        }

        protected override void OnEnter() {}
        protected override void OnExit() {}
    }
}
