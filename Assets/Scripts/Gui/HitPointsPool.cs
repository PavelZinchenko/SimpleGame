using System.Collections.Generic;
using UnityEngine;
using Characters;

namespace Gui
{
    public class HitPointsPool : MonoBehaviour
    {
        private readonly List<HitPoints> _hitPointIndicators = new();

        private void Awake()
        {
            gameObject.GetComponentsInChildren<HitPoints>(_hitPointIndicators);
            foreach (var item in _hitPointIndicators)
                item.gameObject.SetActive(false);
        }

        public void BindHpIndicator(CharacterConfigurator character)
        {
            foreach (var item in _hitPointIndicators)
            {
                if (item.gameObject.activeSelf) continue;
                item.gameObject.SetActive(true);
                item.SetCharacter(character.Stats);
                break;
            }
        }
    }
}
