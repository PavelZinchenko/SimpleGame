using UnityEngine;
using UnityEngine.Events;

namespace Settings
{
    public class PlayerWallet : MonoBehaviour
    {
        [SerializeField] private UnityEvent<int> _coinsChanged;

        private int _coins;
        private const string _coinsKey = "coins";

        public event UnityAction<int> CoinsChanged
        {
            add => (_coinsChanged ??= new()).AddListener(value);
            remove => _coinsChanged.RemoveListener(value);
        }

        public int Coins
        {
            get => _coins;
            set
            {
                if (value == _coins) return;
                _coins = Mathf.Max(0, value);
                _coinsChanged?.Invoke(_coins);
            }
        }

        private void OnEnable() => LoadSettings();
        private void OnDisable() => SaveSettings();

        private void SaveSettings()
        {
            PlayerPrefs.SetInt(_coinsKey, _coins);
        }

        private void LoadSettings()
        {
            _coins = PlayerPrefs.GetInt(_coinsKey);
        }
    }
}
