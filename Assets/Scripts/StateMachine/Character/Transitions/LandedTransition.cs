using UnityEngine;

namespace StateMachine.Character.Transitions
{
    public class LandedTransition : Base.Transition<IContext>
    {
        [SerializeField] private Characters.FallableBody _body;

        public override bool NeedTransit => _body.IsStanding;
    }
}
