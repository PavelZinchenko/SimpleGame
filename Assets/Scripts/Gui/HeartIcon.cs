using UnityEngine;

namespace Gui
{
    [RequireComponent(typeof(Animator))]
    public class HeartIcon : MonoBehaviour
    {
        private readonly int _visible = Animator.StringToHash("visible");
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetVisible(bool visible)
        {
            _animator.SetBool(_visible, visible);
        }
    }
}
