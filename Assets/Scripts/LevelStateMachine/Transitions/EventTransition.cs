namespace LevelStateMachine.Transitions
{
    public class EventTransition : Transition
    {
        private bool _activated;

        public override bool NeedTransit => _activated;

        public override void Init() {}

        public void Activate()
        {
            _activated = true;
        }
    }
}
