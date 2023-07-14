using UnityEngine;
using Zenject;

namespace StateMachine.Level.States
{
    public class InitializationState : Base.State<Context>
    {
        [SerializeField] private Transform _spawnPoint1;
        [SerializeField] private Transform _spawnPoint2;

        [Inject] private readonly PlayerSpawner _playerSpawner;

        private void OnEnable()
        {
            _playerSpawner.SpawnPlayer1(_spawnPoint1.position);
            _playerSpawner.SpawnPlayer2(_spawnPoint2.position);
        }
    }
}
