namespace StateMachine.Character.Transitions
{
    public class DyingTransition : Base.Transition<IContext>
    {
        public override bool NeedTransit => Context.MustDie;
    }
}
