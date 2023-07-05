using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Assertions;

namespace LevelStateMachine
{
    [DisallowMultipleComponent]
    public class State : MonoBehaviour
    {
        [SerializeField] private UnityEvent _activated = new();
        [SerializeField] private UnityEvent _passed = new();

        private List<Transition> _transitions = new();

        private void Awake()
        {
            GetComponents<Transition>(_transitions);
        }

        public void Enter()
        {
            Assert.IsFalse(gameObject.activeSelf);

            gameObject.SetActive(true);
            foreach (var transition in _transitions)
                transition.Init();

            _activated.Invoke();
        }

        public void Exit()
        {
            Assert.IsTrue(gameObject.activeSelf);

            _passed.Invoke();
            gameObject.SetActive(false);
        }

        public State GetNextState()
        {
            foreach (var transition in _transitions)
                if (transition.NeedTransit)
                    return transition.TargetState;

            return null;
        }
    }
}
