using UnityEngine;
using UnityEngine.Events;

namespace Characters
{
    public interface ICharacterStats
    {
        Sprite Icon { get; }
        int Health { get; }

        event UnityAction<int> HealthChanged;
    }
}
