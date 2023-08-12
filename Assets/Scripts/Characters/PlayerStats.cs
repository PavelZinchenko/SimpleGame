using UnityEngine;
using UnityEngine.Events;

namespace Characters
{
    public class PlayerStats : MonoBehaviour, ICharacterStats
    {
        [SerializeField] private PlayableCharacterData _character;
        [SerializeField] private UnityEvent<int> _healthChanged;

        private int _health;

        public Sprite Icon => _character.Icon;
        
        public int Health
        {
            get => _health;
            set
            {
                if (_health == value) return;
                _health = value;
                _healthChanged?.Invoke(_health);
            }
        }

        public event UnityAction<int> HealthChanged
        {
            add => (_healthChanged ??= new()).AddListener(value);
            remove => _healthChanged?.RemoveListener(value);
        }

        private void Awake()
        {
            _health = _character.HitPoints;
        }
    }
}
