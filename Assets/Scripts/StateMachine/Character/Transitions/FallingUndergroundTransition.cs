using UnityEngine;

namespace StateMachine.Character.Transitions
{
    public class FallingUndergroundTransition : Base.Transition<IContext>
    {
        [SerializeField] private Characters.FallableBody _body;

        public override bool NeedTransit => !_body.IsAboveGround;
    }
}
