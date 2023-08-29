using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Level
{
    public class Coin : MonoBehaviour
    {
        [Inject] private Settings.PlayerWallet _wallet;
        [Inject] private Gui.WalletPanel _walletPanel;

        [SerializeField] private int _value = 1;
        [SerializeField] private float _smoothTime = 0.5f;
        [SerializeField] private float _minDistanceToWallet = 0.5f;

        [SerializeField] private UnityEvent _collecting;
        [SerializeField] private UnityEvent _collected;

        public void Collect()
        {
            _collecting?.Invoke();
            _wallet.Coins += _value;
            StartCoroutine(MoveToWallet());
        }

        private IEnumerator MoveToWallet()
        {
            var position = transform.position;
            var velocity = Vector2.zero;
            var elapsedTime = 0f;
            var offset = (Vector2)position - (Vector2)_walletPanel.GetWorldPosition();

            while (true)
            {
                Vector2 walletPosition = _walletPanel.GetWorldPosition();
                elapsedTime += Time.deltaTime;
                offset = Vector2.SmoothDamp(offset, Vector2.zero, ref velocity, _smoothTime);
                position.x = walletPosition.x + offset.x;
                position.y = walletPosition.y + offset.y;
                transform.position = position;

                if (offset.magnitude <= _minDistanceToWallet) break;
                yield return null;
            }

            _collected?.Invoke();
        }
    }
}
