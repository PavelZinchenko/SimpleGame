using UnityEngine;
using UnityEngine.Events;

namespace Characters
{
    public class CharacterStats : MonoBehaviour, ICharacterStats
    {
        [SerializeField] private int _health;
        [SerializeField] private Sprite _icon;
        [SerializeField] private CharacterType _type;

        public CharacterType Type => _type;
        public Sprite Icon => _icon;
        public int Health => _health;

        public event UnityAction<int> HealthChanged 
        {
            add => throw new System.InvalidOperationException();
            remove => throw new System.InvalidOperationException();
        }
    }
}
