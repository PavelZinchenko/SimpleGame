using UnityEngine;
using UnityEngine.Events;
using Characters;

namespace GameLevel
{
    public class CharacterSpawner : MonoBehaviour
    {
        [SerializeField] private UnityEvent<CharacterConfigurator> _characterSpawned;

        public event UnityAction<CharacterConfigurator> CharacterSpawned
        {
            add => (_characterSpawned ??= new()).AddListener(value);
            remove => _characterSpawned.RemoveListener(value);
        }

        public T Spawn<T>(T prefab, Vector3 position) where T : CharacterConfigurator
        {
            var instance = Instantiate(prefab, position, Quaternion.identity);
            _characterSpawned?.Invoke(instance);
            return instance;
        }
    }
}
