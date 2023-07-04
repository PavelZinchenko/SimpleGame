using UnityEngine;

namespace LevelStateMachine
{
    public class Transition : MonoBehaviour
    {
        [SerializeField] private State _targetState;

        public State TargetState => _targetState;

        public virtual bool NeedTransit => true;

        public virtual void Init() { }
    }
}
