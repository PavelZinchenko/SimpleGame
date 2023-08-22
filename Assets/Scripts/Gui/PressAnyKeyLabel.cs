using UnityEngine;
using UnityEngine.InputSystem;

namespace Gui
{
    public class PressAnyKeyLabel : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private TMPro.TMP_Text _message;
        [SerializeField] private string _activationKeyName = "Jump";
        [SerializeField] private string _text = "Press [{0}] to continue";

        private void Awake()
        {
            var keyName = _playerInput.actions.FindAction(_activationKeyName).bindings[0].ToDisplayString();
            _message.text = string.Format(_text, keyName);
        }
    }
}
