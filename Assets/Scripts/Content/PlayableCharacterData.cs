using UnityEngine;

namespace Content
{
    [CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character", order = 1)]
    public class PlayableCharacterData : ScriptableObject
    {
        [SerializeField] private Characters.CharacterConfigurator _prefab;
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private RuntimeAnimatorController _uiAnimation;
        [SerializeField] private int _hitPoints;
        [SerializeField] private int _price;

        public Characters.CharacterConfigurator Prefab => _prefab;
        public Sprite Icon => _icon;
        public RuntimeAnimatorController UiAnimation => _uiAnimation;
        public string Name => _name;
        public int HitPoints => _hitPoints;
        public int Price => _price;
    }
}
