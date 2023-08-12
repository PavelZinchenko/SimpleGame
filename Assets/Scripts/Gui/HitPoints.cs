using System.Collections.Generic;
using UnityEngine;
using Characters;

namespace Gui
{
    public class HitPoints : MonoBehaviour
    {
        [SerializeField] private Transform _HealthBar;
        [SerializeField] private UnityEngine.UI.Image _icon;
        [SerializeField] private UnityEngine.UI.Image _deadIcon;

        private ICharacterStats _stats;
        private readonly List<HeartIcon> _hearts = new();

        private void OnDestroy()
        {
            Cleanup();
        }

        public void SetCharacter(ICharacterStats stats)
        {
            Cleanup();
            _stats = stats;
            _icon.sprite = _stats.Icon;
            _stats.HealthChanged += OnHealthChanged;
            CreateHealthIcons(_stats.Health);
        }

        private void OnHealthChanged(int hitpoints)
        {
            for (var i = 0; i < _hearts.Count; ++i)
                _hearts[i].SetVisible(i < hitpoints);

            if (hitpoints <= 0)
            {
                _deadIcon.gameObject.SetActive(true);
                _icon.gameObject.SetActive(false);
            }
        }

        private void Cleanup()
        {
            if (_stats != null)
            {
                _stats.HealthChanged -= OnHealthChanged;
                _stats = null;
            }
        }

        private void CreateHealthIcons(int maxHealth)
        {
            _hearts.Clear();

            foreach (Transform child in _HealthBar)
            {
                var item = child.GetComponent<HeartIcon>();
                if (item == null)
                    continue;

                if (_hearts.Count >= maxHealth)
                {
                    item.gameObject.SetActive(false);
                    continue;
                }

                item.gameObject.SetActive(true);
                _hearts.Add(item);
            }

            if (_hearts.Count == 0)
                throw new System.InvalidOperationException();

            var prefab = _hearts[0];

            for (var i = _hearts.Count; i < maxHealth; ++i)
            {
                var newItem = Instantiate<HeartIcon>(prefab, _HealthBar);
                _hearts.Add(newItem);
                //var rectTransform = newItem.GetComponent<RectTransform>();
                //rectTransform.SetParent(parent);
                //rectTransform.localScale = Vector3.one;
                //rectTransform.SetSiblingIndex(++index);
                //newItem.gameObject.SetActive(true);
                //Initializer(newItem, enumerator.Current);
                //count++;
            }
        }
    }
}
