using UnityEngine;

namespace StateMachine.Character.States
{
    public class JumpingState : Base.State<IContext>
    {
        [SerializeField] private float _jumpSpeed = 8;
        [SerializeField] private Characters.FallableBody _body;

        private void OnEnable()
        {
            _body.Speed = _jumpSpeed;
        }
    }
}
