using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace GameLevel
{
    public class CharacterSpawnDetector : MonoBehaviour
    {
        [Inject] private CharacterSpawner _characterSpawner;

        [SerializeField] private Characters.CharacterType _requiredType = Characters.CharacterType.Undefined;
        [SerializeField] private UnityEvent<Characters.CharacterConfigurator> _characterSpawned;

        private void OnEnable()
        {
            _characterSpawner.CharacterSpawned += OnCharacterSpawned;
        }

        private void OnDisable()
        {
            _characterSpawner.CharacterSpawned += OnCharacterSpawned;
        }

        private void OnCharacterSpawned(Characters.CharacterConfigurator character)
        {
            if (_requiredType == Characters.CharacterType.Undefined || character.Stats.Type == _requiredType)
                _characterSpawned?.Invoke(character);
        }
    }
}
