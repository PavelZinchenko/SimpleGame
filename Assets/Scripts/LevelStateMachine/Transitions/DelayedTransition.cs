using UnityEngine;

namespace LevelStateMachine.Transitions
{
    public class DelayedTransition : Transition
    {
        [SerializeField] private float _timeInterval = 5f;

        private float _startTime;

        public override bool NeedTransit => Time.time >= _startTime + _timeInterval;

        public override void Init()
        {
            _startTime = Time.time;
        }
    }
}
