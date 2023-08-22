using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character", order = 1)]
    public class PlayableCharacterData : ScriptableObject
    {
        [SerializeField] private CharacterConfigurator _prefab;
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _hitPoints;
        [SerializeField] private int _price;

        public CharacterConfigurator Prefab => _prefab;
        public Sprite Icon => _icon;
        public string Name => _name;
        public int HitPoints => _hitPoints;
        public int Price => _price;
    }
}
