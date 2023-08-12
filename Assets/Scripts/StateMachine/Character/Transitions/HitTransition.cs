namespace StateMachine.Character.Transitions
{
    public class HitTransition : Base.Transition<IContext>
    {
        public override bool NeedTransit => Context.GotHit;
    }
}
