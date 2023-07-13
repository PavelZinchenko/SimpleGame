using UnityEngine;

namespace StateMachine.Character.States
{
    public class WalkingState : Base.State<IContext>
    {
        [SerializeField] private float _movementSpeed = 4;
        [SerializeField] private float _acceleration = 300;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Characters.AnimationController _animation;

        private void Update()
        {
            var velocity = _rigidbody2D.velocity;
            var desiredVelocity = Context.MovementDirection * _movementSpeed;
            _rigidbody2D.AddForce(_acceleration * Time.deltaTime * (desiredVelocity - velocity));
            _animation.Walk(velocity / _movementSpeed);

            //if (Context.MustDie)
            //    Transition = _deadState;
            //else if (Context.WantToJump && _jumpingState != null)
            //    Transition = _jumpingState;
            //else if (_groundDetector && !_groundDetector.Grounded && _fallingState != null)
            //    Transition = _fallingState;
        }
    }
}
