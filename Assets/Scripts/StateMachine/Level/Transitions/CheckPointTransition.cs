using UnityEngine;

namespace StateMachine.Level.Transitions
{
    public class CheckPointTransition : Base.Transition<Context>
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _checkpoint;
        [SerializeField] private bool _canTriggerMultipleTimes;

        private bool _triggered;

        public override bool NeedTransit
        {
            get
            {
                if (_triggered && !_canTriggerMultipleTimes) return false;
                if (_camera.position.x < _checkpoint.position.x) return false;

                _triggered = true;
                return true;
            }
        }
    }
}
