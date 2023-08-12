using UnityEngine;

namespace StateMachine.Base
{
    public abstract class StateMachine<T> : MonoBehaviour
    {
        [SerializeField] private State<T> _firstState;

        private State<T> _currentState;

        protected abstract T Context { get; }

        private void Start()
        {
            Transit(_firstState);
        }

        private void Update()
        {
            if (_currentState == null)
                return;

            var nextState = _currentState.GetNextState();
            if (nextState != null)
                Transit(nextState);

            OnUpdated();
        }

        protected virtual void OnUpdated() { }

        private void Transit(State<T> nextState)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = nextState;

            if (_currentState != null)
                _currentState.Enter(Context);
        }
    }
}
