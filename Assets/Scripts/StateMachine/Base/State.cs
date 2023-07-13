using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Assertions;

namespace StateMachine.Base
{
    [DisallowMultipleComponent]
    public class State<T> : MonoBehaviour
    {
        [SerializeField] private UnityEvent _entered;
        [SerializeField] private UnityEvent _exiting;

        private readonly List<Transition<T>> _transitions = new();

        protected T Context { get; private set; }

        private void Awake()
        {
            GetComponents(_transitions);
        }

        public void Enter(T context)
        {
            Assert.IsFalse(gameObject.activeSelf);

            Context = context;
            gameObject.SetActive(true);
            foreach (var transition in _transitions)
                transition.Init(context);
            _entered?.Invoke();
        }

        public void Exit()
        {
            Assert.IsTrue(gameObject.activeSelf);

            _exiting?.Invoke();
            gameObject.SetActive(false);
        }

        public State<T> GetNextState()
        {
            foreach (var transition in _transitions)
                if (transition.NeedTransit)
                    return transition.TargetState;

            return null;
        }
    }
}
