using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace Gui
{
    [RequireComponent(typeof(PlayerInput))]
    public class CharacterSelectionWindow : MonoBehaviour
    {
        [SerializeField] private GameObject _pressAnyKeyLabel;
        [SerializeField] private GameObject _selectionPanel;
        [SerializeField] private Image _characterIcon;
        [SerializeField] private TMPro.TMP_Text _characterName;
        [SerializeField] private Characters.PlayableCharacterList _characterList;
        [SerializeField] private float _animationSpeed = 5;

        [SerializeField] private UnityEvent<int> _characterChanged;

        private const string _hiddenCharacterName = "???";

        private bool _activated;
        private bool _isCoroutineRunning;
        private int _characterIndex = -1;

        private void Start()
        {
            _pressAnyKeyLabel.SetActive(true);
            _selectionPanel.SetActive(false);
        }

        public void Activate()
        {
            if (_activated) return;
            _activated = true;

            _pressAnyKeyLabel.SetActive(false);
            _selectionPanel.SetActive(true);

            SelectCharacter(0);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Performed) return;
            
            if (!_activated)
            {
                Activate();
                return;
            }

            var direction = context.ReadValue<Vector2>();
            if (direction.x < 0 || direction.y < 0)
                SelectCharacter(_characterIndex - 1);
            else if (direction.x > 0 || direction.y > 0)
                SelectCharacter(_characterIndex + 1);
        }

        private void SelectCharacter(int index)
        {
            var newIndex = Mathf.Clamp(index, 0, _characterList.Count - 1);
            if (newIndex == _characterIndex) return;

            _characterIndex = newIndex;
            if (IsLocked(newIndex))
            {
                _characterName.text = _hiddenCharacterName;
            }
            else
            {
                _characterName.text = _characterList[newIndex].Name;
                _characterChanged?.Invoke(newIndex);
            }

            if (!_isCoroutineRunning)
                StartCoroutine(ChangeCharacterIcon());
        }

        private bool IsLocked(int index)
        {
            return false; //_characterList[index].Price > 0;
        }

        private IEnumerator ChangeCharacterIcon()
        {
            if (_isCoroutineRunning) yield break;
            _isCoroutineRunning = true;

            var characterIndex = _characterIndex;
            bool iconChanged = false;
            bool finished = false;

            var color = _characterIcon.color;

            const float minAlpha = 0f;
            const float maxAlpha = 1f;

            while (!finished)
            {
                if (_characterIndex != characterIndex)
                {
                    iconChanged = false;
                    characterIndex = _characterIndex;
                }

                if (iconChanged)
                {
                    color.a += Time.deltaTime * _animationSpeed;
                    if (color.a >= maxAlpha)
                    {
                        color.a = maxAlpha;
                        finished = true;
                    }
                }
                else
                {
                    color.a -= Time.deltaTime * _animationSpeed;
                    if (color.a <= minAlpha)
                    {
                        color = IsLocked(characterIndex) ? Color.black : Color.white;
                        color.a = minAlpha;
                        var character = _characterList[characterIndex];
                        _characterIcon.sprite = character.Icon;
                        iconChanged = true;
                    }
                }

                _characterIcon.color = color;
                
                if (!finished) 
                    yield return null;
            }

            _isCoroutineRunning = false;
        }
    }
}
