using UnityEngine;

namespace Model
{
    public class GameSettings : MonoBehaviour
    {
        [SerializeField] private Characters.PlayableCharacterList _characterList;

        private int _player1CharacterId;
        private int _player2CharacterId;
        private const int _nullCharacterId = -1;

        private const string _player1CharacterIdKey = "player1";
        private const string _player2CharacterIdKey = "player2";

        private void OnEnable() => LoadSettings();
        private void OnDisable() => SaveSettings();

        public void SetPlayer1CharacterId(int index) => _player1CharacterId = index;
        public void SetPlayer2CharacterId(int index) => _player2CharacterId = index;

        public Characters.PlayableCharacterData GetPlayer1Character() => _characterList[_player1CharacterId];
        public Characters.PlayableCharacterData GetPlayer2Character() => _characterList[_player2CharacterId];

        private void SaveSettings()
        {
            PlayerPrefs.SetInt(_player1CharacterIdKey, _player1CharacterId);
            PlayerPrefs.SetInt(_player2CharacterIdKey, _player2CharacterId);
        }

        private void LoadSettings()
        {
            _player1CharacterId = PlayerPrefs.GetInt(_player1CharacterIdKey, _nullCharacterId);
            _player2CharacterId = PlayerPrefs.GetInt(_player2CharacterIdKey, _nullCharacterId);
        }
    }
}
