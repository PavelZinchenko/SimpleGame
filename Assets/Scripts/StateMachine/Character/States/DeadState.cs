using UnityEngine;

namespace StateMachine.Character.States
{
    public class DeadState : Base.State<IContext>
    {
        [SerializeField] private GameObject _objectToDestroy;
        [SerializeField] private Characters.AnimationController _animation;

        private void OnEnable()
        {
            Debug.Log("I am dead - " + (_objectToDestroy != null ? _objectToDestroy.name : gameObject.name));

            _animation.Die();

            //if (_objectToDestroy)
            //    Destroy(_objectToDestroy);
        }
    }
}
