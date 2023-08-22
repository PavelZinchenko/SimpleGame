using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gui
{
    public class WalletPanel : MonoBehaviour
    {
        [Inject] private Settings.PlayerWallet _playerWallet;

        [SerializeField] private Image _coinIcon;
        [SerializeField] private TMPro.TMP_Text _coinsText;

        private void OnEnable()
        {
            _playerWallet.CoinsChanged += SetValue;
        }

        private void OnDisable()
        {
            _playerWallet.CoinsChanged -= SetValue;
        }

        private void Start()
        {
            SetValue(_playerWallet.Coins);
        }

        public Vector3 GetWorldPosition()
        {
            return Camera.main.ScreenToWorldPoint(_coinIcon.transform.position);
        }

        private void SetValue(int value)
        {
            _coinsText.text = value.ToString();
        }
    }
}
