using UnityEngine;
using UnityEngine.Events;

namespace Characters
{
    public class GroundDetector : MonoBehaviour
    {
        [SerializeField] private UnityEvent _leftGround;
        [SerializeField] private UnityEvent _gotToGround;

        private Level.ILevelMap _levelMap;

        private bool _grounded = true;

        public bool Grounded 
        {
            get => _grounded; 
            set
            {
                if (_grounded == value) return;
                _grounded = value;

                if (_grounded)
                    _gotToGround?.Invoke();
                else
                    _leftGround?.Invoke();
            }
        }

        public void AssignLevelMap(Level.ILevelMap map) => _levelMap = map;

        private void Update()
        {
            if (_levelMap != null)
                Grounded = _levelMap.HasFloor(transform.position);
        }
    }
}
