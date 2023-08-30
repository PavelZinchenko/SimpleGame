using System.Collections.Generic;
using UnityEngine;

namespace Content
{
    [CreateAssetMenu(fileName = "CharacterList", menuName = "ScriptableObjects/CharacterList", order = 1)]
    public class PlayableCharacterList : ScriptableObject
    {
        [SerializeField] private List<PlayableCharacterData> _characters = new();

        public int Count => _characters.Count;
        public PlayableCharacterData this[int index] => index < 0 || index >= Count ? null : _characters[index];
        public IEnumerable<PlayableCharacterData> Characters => _characters;
    }
}
