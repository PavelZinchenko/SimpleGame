using UnityEngine;

namespace StateMachine.Character.Transitions
{
    public class JumpedTransition : Base.Transition<IContext>
    {
        [SerializeField] private Characters.FallableBody _body;

        public override bool NeedTransit => Context.WantToJump && _body.IsStanding;
    }
}
