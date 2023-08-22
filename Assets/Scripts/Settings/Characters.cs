using System;
using System.Collections.Generic;
using UnityEngine;
using Characters;

namespace Settings
{
    public enum PlayerId
    {
        Player1,
        Player2,
    }

    public class Characters : MonoBehaviour
    {
        [SerializeField] private PlayableCharacterList _characterList;

        private readonly HashSet<int> _unlockedCharacters = new();

        private int _player1;
        private int _player2;

        private const int _nullCharacterId = -1;
        private const char _separator = ' ';
        private const string _player1Key = "player1";
        private const string _player2Key = "player2";
        private const string _charactersKey = "characters";

        private void OnEnable() => LoadSettings();
        private void OnDisable() => SaveSettings();

        public void Reset()
        {
            _player1 = _nullCharacterId;
            _player2 = _nullCharacterId;
        }

        public void SelectPlayerCharacter(PlayerId playerId, int characterId)
        {
            switch (playerId)
            {
                case PlayerId.Player1: _player1 = characterId; break;
                case PlayerId.Player2: _player2 = characterId; break;
                default: throw new System.InvalidOperationException();
            }
        }

        public bool TryUnlock(int characterId, PlayerWallet wallet)
        {
            if (!IsLocked(characterId)) return false;
            
            var price = _characterList[characterId].Price;
            if (wallet.Coins < price) return false;

            wallet.Coins -= price;
            _unlockedCharacters.Add(characterId);
            return true;
        }

        public bool IsLocked(int characterId)
        {
            var character = _characterList[characterId];
            return character != null && character.Price > 0 && !_unlockedCharacters.Contains(characterId);
        }

        public PlayableCharacterData GetPlayerCharacter(PlayerId playerId)
        {
            switch (playerId)
            {
                case PlayerId.Player1: return _characterList[_player1];
                case PlayerId.Player2: return _characterList[_player2];
                default: return null;
            }
        }

        private void SaveSettings()
        {
            PlayerPrefs.SetInt(_player1Key, _player1);
            PlayerPrefs.SetInt(_player2Key, _player2);
            PlayerPrefs.SetString(_charactersKey, string.Join(_separator, _unlockedCharacters));
        }

        private void LoadSettings()
        {
            _player1 = PlayerPrefs.GetInt(_player1Key, _nullCharacterId);
            _player2 = PlayerPrefs.GetInt(_player2Key, _nullCharacterId);

            var characters = PlayerPrefs.GetString(_charactersKey, string.Empty).Split(_separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in characters)
                if (int.TryParse(item, out var id))
                    _unlockedCharacters.Add(id);
        }
    }
}
