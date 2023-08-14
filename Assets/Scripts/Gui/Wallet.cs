using UnityEngine;
using UnityEngine.UI;

namespace Gui
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private Image _coinIcon;
        [SerializeField] private TMPro.TMP_Text _coinsText;

        private int _coins;

        private void Start()
        {
            UpdateText();
        }

        public void AddCoin(int count = 1)
        {
            _coins += count;
            UpdateText();
        }

        public Vector3 GetWorldPosition()
        {
            return Camera.main.ScreenToWorldPoint(_coinIcon.transform.position);
        }

        private void UpdateText()
        {
            _coinsText.text = _coins.ToString();
        }
    }
}
