using UnityEngine;
using Zenject;

namespace StateMachine.Level.Transitions
{
    public class CheckPointTransition : Base.Transition<Context>
    {
        [Inject] private readonly CameraController _camera;

        [SerializeField] private Transform _checkpoint;
        [SerializeField] private bool _canTriggerMultipleTimes;

        private bool _triggered;

        public override bool NeedTransit
        {
            get
            {
                if (_triggered && !_canTriggerMultipleTimes) return false;
                if (_camera.transform.position.x < _checkpoint.position.x) return false;

                _triggered = true;
                return true;
            }
        }
    }
}
