using UnityEngine;

namespace LevelStateMachine
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private State _firstState;

        private State _currentState;

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
        }

        private void Transit(State nextState)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = nextState;

            if (_currentState != null)
                _currentState.Enter();
        }
    }
}
