using System.Collections;
using UnityEngine;

namespace StateMachine.Character.States
{
    public class DeadState : Base.State<IContext>
    {
        [SerializeField] private Characters.AnimationController _animation;
        [SerializeField] private GameObject _objectToDestroy;
        [SerializeField] private float _delay = 3f;

        private void OnEnable()
        {
            Debug.Log("I am dead - " + (_objectToDestroy != null ? _objectToDestroy.name : gameObject.name));

            _animation.Die();

            if (_objectToDestroy)
                StartCoroutine(WaitThenDestroy());
        }

        private IEnumerator WaitThenDestroy()
        {
            yield return new WaitForSeconds(_delay);
            Destroy(_objectToDestroy);
        }
    }
}
