using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Assertions;

namespace GameStateMachine
{
    [DisallowMultipleComponent]
    public class State : MonoBehaviour
    {
        [SerializeField] private List<Transition> _transitions = new();
        [SerializeField] private UnityEvent _activated = new();

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
