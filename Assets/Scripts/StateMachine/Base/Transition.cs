using UnityEngine;

namespace StateMachine.Base
{
    public class Transition<T> : MonoBehaviour
    {
        [SerializeField] private State<T> _targetState;

        public State<T> TargetState => _targetState;
        public virtual bool NeedTransit => true;

        protected T Context { get; private set; }

        public void Init(T context) => Context = context; 
    }
}
