using UnityEngine;

namespace StateMachine.Character.States
{
    public class WalkingState : Base.State<IContext>
    {
        [SerializeField] private float _movementSpeed = 4;
        [SerializeField] private float _acceleration = 300;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Characters.AnimationController _animation;

        private void FixedUpdate()
        {
            var velocity = _rigidbody2D.velocity;
            var desiredVelocity = Context.MovementDirection * _movementSpeed;
            _rigidbody2D.AddForce(_acceleration * Time.fixedDeltaTime * (desiredVelocity - velocity));
            _animation.Walk(velocity / _movementSpeed);
        }
    }
}
