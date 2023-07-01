using UnityEngine;

namespace GameStateMachine.Transitions
{
    public class CheckPointTransition : Transition
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

        public override void Init() {}
    }
}
