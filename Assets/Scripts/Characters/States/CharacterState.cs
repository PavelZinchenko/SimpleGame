using UnityEngine;
using UnityEngine.Assertions;

namespace Characters.States
{
    public abstract class CharacterState : MonoBehaviour
    {
        public CharacterState Transition { get; protected set; }
        protected IContext Context { get; private set; }

        private void Awake()
        {
            Assert.IsFalse(enabled);
        }

        public void Enter(IContext context)
        {
            Assert.IsFalse(enabled);
            enabled = true;

            Transition = null;
            Context = context;

            OnEnter();
        }

        public void Exit()
        {
            Assert.IsTrue(enabled);
            enabled = false;

            OnExit();
        }

        protected abstract void OnEnter();
        protected abstract void OnExit();
    }
}
