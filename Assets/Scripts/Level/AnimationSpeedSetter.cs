using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(Animator))]
    public class AnimationSpeedSetter : MonoBehaviour
    {
        [SerializeField] private float _speedMin = 0.75f;
        [SerializeField] private float _speedMax = 1.25f;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _animator.speed = Random.Range(_speedMin, _speedMax);
        }
    }
}
