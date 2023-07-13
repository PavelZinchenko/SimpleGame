using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Characters
{
    public class GroundDetector : MonoBehaviour
    {
        [Inject] private readonly LevelMap _levelMap;

        [SerializeField] private UnityEvent _leftGround;
        [SerializeField] private UnityEvent _gotToGround;

        private Vector3Int _cell;
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

        private void Update()
        {
            var position = transform.position;
            var cell = _levelMap.WorldToCell(position);
            if (cell == _cell) return;
            _cell = cell;

            Grounded = _levelMap.HasTile(cell);
        }
    }
}
