using UnityEngine;
using UnityEngine.Events;

namespace Characters.States
{
    public class JumpingState : CharacterState
    {
        [SerializeField] private float _jumpSpeed = 8;
        [SerializeField] private FallingState _fallTransition;

        [SerializeField] private UnityEvent _jumped = new();

        private void Update()
        {
        }

        protected override void OnEnter() 
        {
            if (Context.Grounded && Context.WantToJump)
            {
                _fallTransition.InitialSpeed = _jumpSpeed;
                _jumped.Invoke();
            }

            Transition = _fallTransition;
        }

        protected override void OnExit() 
        {
        }
    }
}
