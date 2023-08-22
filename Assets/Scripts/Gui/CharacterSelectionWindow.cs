using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Gui
{
    public class CharacterSelectionWindow : MonoBehaviour
    {
        [Inject] private readonly Settings.PlayerWallet _playerWallet;
        [Inject] private readonly Settings.Characters _characters;

        [SerializeField] private PressAnyKeyLabel _pressAnyKeyLabel;
        [SerializeField] private GameObject _selectionPanel;
        [SerializeField] private GameObject _lockedPanel;
        [SerializeField] private Image _characterIcon;
        [SerializeField] private TMPro.TMP_Text _characterName;
        [SerializeField] private TMPro.TMP_Text _priceText;
        [SerializeField] private Characters.PlayableCharacterList _characterList;

        [SerializeField] private Settings.PlayerId _playerId;
        [SerializeField] private float _animationSpeed = 5;
        [SerializeField] private string _hiddenCharacterName = "???";

        [SerializeField] private UnityEvent<int> _characterSelected;

        private bool _activated;
        private bool _isCoroutineRunning;
        private int _characterIndex = -1;

        private void Start()
        {
            _pressAnyKeyLabel.gameObject.SetActive(true);
            _selectionPanel.SetActive(false);
        }

        public void Activate()
        {
            if (!_activated)
            {
                _activated = true;

                _pressAnyKeyLabel.gameObject.SetActive(false);
                _selectionPanel.SetActive(true);

                SelectCharacter(0);

                return;
            }

            UnlockCharacter();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Performed) return;
            if (!_activated) return;

            var direction = context.ReadValue<Vector2>();
            if (direction.x < 0 || direction.y < 0)
                SelectCharacter(Repeat(_characterIndex - 1, _characterList.Count));
            else if (direction.x > 0 || direction.y > 0)
                SelectCharacter(Repeat(_characterIndex + 1, _characterList.Count));
        }

        private void SelectCharacter(int index)
        {
            _characterIndex = Mathf.Clamp(index, 0, _characterList.Count - 1);
            var character = _characterList[_characterIndex];

            if (_characters.IsLocked(_characterIndex))
            {
                _lockedPanel.SetActive(true);
                _priceText.text = character.Price.ToString();
                _characterName.text = _hiddenCharacterName;
            }
            else
            {
                _lockedPanel.SetActive(false);
                _characterName.text = character.Name;
                _characters.SelectPlayerCharacter(_playerId, _characterIndex);
                _characterSelected?.Invoke(_characterIndex);
            }

            if (!_isCoroutineRunning)
                StartCoroutine(ChangeCharacterIcon());
        }

        private void UnlockCharacter()
        {
            if (_characters.TryUnlock(_characterIndex, _playerWallet))
                SelectCharacter(_characterIndex);
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
                        color = _characters.IsLocked(characterIndex) ? Color.black : Color.white;
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

        private static int Repeat(int index, int length) => ((index %= length) < 0) ? index + length : index;
    }
}
