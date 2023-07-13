using UnityEngine;
using Zenject;

namespace StateMachine.Level.States
{
    public class InitializationState : Base.State<Context>
    {
        [SerializeField] private PlayerController _playerPrefab1;
        [SerializeField] private PlayerController _playerPrefab2;

        [SerializeField] private Transform _spawnPoint1;
        [SerializeField] private Transform _spawnPoint2;
        [SerializeField] private Camera.FollowCamera _camera;

        [Inject] private readonly Services.GameObjectFactory _objectFactory;

        private void OnEnable()
        {
            var player1 = CreatePlayer(_playerPrefab1, _spawnPoint1);
            var player2 = CreatePlayer(_playerPrefab2, _spawnPoint2);

            _camera.Initialize(player1.transform, player2.transform);
        }

        private PlayerController CreatePlayer(PlayerController prefab, Transform spawnPoint)
        {
            var player = _objectFactory.Create(prefab);
            player.transform.position = spawnPoint.position;
            return player;
        }
    }
}
