using UnityEngine;

namespace StateMachine.Level.Transitions
{
    public class DelayedTransition : Base.Transition<Context>
    {
        [SerializeField] private float _timeInterval = 5f;

        private float _startTime;

        public override bool NeedTransit => Time.time >= _startTime + _timeInterval;

        private void OnEnable()
        {
            _startTime = Time.time;
        }
    }
}
