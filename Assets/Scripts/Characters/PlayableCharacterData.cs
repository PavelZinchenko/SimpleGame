using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character", order = 1)]
    public class PlayableCharacterData : ScriptableObject
    {
        [SerializeField] private Ai.PlayerBehaviour _prefab;
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _hitPoints;

        public Ai.PlayerBehaviour Prefab => _prefab;
    }
}
