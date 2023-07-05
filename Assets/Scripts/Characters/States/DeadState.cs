using UnityEngine;

namespace Characters.States
{
    public class DeadState : CharacterState
    {
        [SerializeField] private GameObject _objectToDestroy;

        private void Update()
        {
        }

        protected override void OnEnter() 
        {
            Debug.Log("I am dead - " + (_objectToDestroy != null ? _objectToDestroy.name : gameObject.name));

            if (_objectToDestroy)
                Destroy(_objectToDestroy);
        }

        protected override void OnExit() { }
    }
}
