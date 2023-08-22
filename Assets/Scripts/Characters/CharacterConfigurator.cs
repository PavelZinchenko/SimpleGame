using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Characters
{
    [RequireComponent(typeof(ICharacterStats))]
    public class CharacterConfigurator : MonoBehaviour
    {
        [InjectOptional] private readonly Level.ILevelMap _levelMap;
        [SerializeField] private GroundDetector _groundDetector;

        private ICharacterStats _stats;

        public ICharacterStats Stats => _stats;

        private void Awake()
        {
            _stats = GetComponent<ICharacterStats>();

            if (_levelMap != null)
                AssignLevelMap(_levelMap);
        }

        public void AssignLevelMap(Level.ILevelMap map)
        {
            _groundDetector?.AssignLevelMap(map);
        }

        public void SetInputActionMap(string name)
        {
            if (TryGetComponent<PlayerInput>(out var playerInput))
                playerInput.SwitchCurrentActionMap(name);
        }
    }
}
