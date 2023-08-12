using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(ICharacterStats))]
    public class PlayerPrefabInitializer : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private ICharacterStats _stats;

        public ICharacterStats Stats => _stats;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _stats = GetComponent<ICharacterStats>();
        }

        public void SetInputActionMap(string name)
        {
            _playerInput.SwitchCurrentActionMap(name);
        }
    }
}
