using UnityEngine;
using UnityEngine.Events;

namespace Characters
{
    public enum CharacterType
    {
        Undefined,
        Player,
        Enemy,
    }

    public interface ICharacterStats
    {
        CharacterType Type { get; }
        Sprite Icon { get; }
        int Health { get; }

        event UnityAction<int> HealthChanged;
    }
}
