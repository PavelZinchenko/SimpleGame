using UnityEngine;
using Zenject;

namespace StateMachine.Level.States
{
    public class InitializationState : Base.State<Context>
    {
        [Inject] private readonly PlayerSpawner _playerSpawner;
        [Inject] private readonly CameraController _camera;

        [SerializeField] private Transform _spawnPoint1;
        [SerializeField] private Transform _spawnPoint2;

        private void OnEnable()
        {
            var player1 = _playerSpawner.SpawnPlayer1(_spawnPoint1.position);
            var player2 = _playerSpawner.SpawnPlayer2(_spawnPoint2.position);

            _camera.TrackTargets(player1.transform, player2.transform);
        }
    }
}
