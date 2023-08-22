using System.Collections;
using UnityEngine;
using Zenject;

namespace Level
{
    public class Coin : MonoBehaviour
    {
        [Inject] private Settings.PlayerWallet _wallet;
        [Inject] private Gui.WalletPanel _walletPanel;

        [SerializeField] private float _smoothTime = 0.5f;
        [SerializeField] private float _minDistanceToWallet = 0.5f;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Animator _animator;

        private void Start()
        {
            _animator.speed = 1f + Random.value * 0.5f;
        }

        public void Collect()
        {
            _collider.enabled = false;
            _wallet.Coins++;
            StartCoroutine(MoveToWallet());
        }

        private IEnumerator MoveToWallet()
        {
            var position = transform.position;
            var position2d = (Vector2)position;
            var velocity = Vector2.zero;
            var elapsedTime = 0f;

            while (true)
            {
                Vector2 target = _walletPanel.GetWorldPosition();
                elapsedTime += Time.deltaTime;
                position2d = Vector2.SmoothDamp(position2d, target, ref velocity, _smoothTime);
                position.x = position2d.x;
                position.y = position2d.y;
                transform.position = position;

                if (Vector2.Distance(position2d, target) <= _minDistanceToWallet) break;
                yield return null;
            }

            Destroy(gameObject);
        }
    }
}
