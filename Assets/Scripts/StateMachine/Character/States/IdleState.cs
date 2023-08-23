using UnityEngine;

namespace StateMachine.Character.States
{
    public class IdleState : Base.State<IContext>
    {
        [SerializeField] private float _deceleration = 300f;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Characters.AnimationController _animation;

        private void OnEnable()
        {
            _animation.Walk(Vector2.zero);
        }

        private void FixedUpdate()
        {
            _rigidbody2D.AddForce(-_deceleration * Time.fixedDeltaTime * _rigidbody2D.velocity);
        }
    }
}
