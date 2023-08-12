using UnityEngine;

namespace StateMachine.Character.Transitions
{
    public class DelayedTransition : Base.Transition<IContext>
    {
        [SerializeField] private float _timeInterval = 1f;

        private float _startTime;

        public override bool NeedTransit => Time.time >= _startTime + _timeInterval;

        private void OnEnable()
        {
            _startTime = Time.time;
        }
    }
}
