using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace StateMachine.Level.States
{
    public class InitializationState : Base.State<Context>
    {
        [Inject] private readonly PlayerSpawner _playerSpawner;

        [SerializeField] private Transform _spawnPoint1;
        [SerializeField] private Transform _spawnPoint2;

        [SerializeField] private UnityEvent<GameObject> _playerCreated;

        private void OnEnable()
        {
            var player1 = _playerSpawner.SpawnPlayer1(_spawnPoint1.position);
            var player2 = _playerSpawner.SpawnPlayer2(_spawnPoint2.position);

            if (player1)
                _playerCreated.Invoke(player1.gameObject);
            if (player2)
                _playerCreated.Invoke(player2.gameObject);
        }
    }
}
