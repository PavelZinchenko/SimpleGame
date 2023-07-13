namespace StateMachine.Level.Transitions
{
    public class EventTransition : Base.Transition<Context>
    {
        private bool _activated;

        public override bool NeedTransit => _activated;

        public void Activate()
        {
            _activated = true;
        }
    }
}
