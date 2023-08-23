using UnityEngine;

namespace StateMachine.Character.Transitions
{
    public class DelayedTransition : Base.Transition<IContext>
    {
        [SerializeField] private float _timeInterval = 1f;
        [SerializeField] private float _randomRange = 0f;

        private float _startTime;

        public override bool NeedTransit => Time.time >= _startTime + _timeInterval;

        private void OnEnable()
        {
            _startTime = Time.time;
            
            if (_randomRange > 0)
                _startTime += Random.Range(-_randomRange, _randomRange);
        }
    }
}
