using UnityEngine;

namespace GameStateMachine.States
{
    public class InitLevelState : State
    {
        [SerializeField] private Transform _playerPrefab1;
        [SerializeField] private Transform _playerPrefab2;

        [SerializeField] private Transform _spawnPoint1;
        [SerializeField] private Transform _spawnPoint2;
        [SerializeField] private Camera.FollowCamera _camera;

        private void OnEnable()
        {
            var player1 = CreatePlayer(_playerPrefab1, _spawnPoint1);
            var player2 = CreatePlayer(_playerPrefab2, _spawnPoint2);
            _camera.Initialize(player1, player2);
        }

        private static Transform CreatePlayer(Transform prefab, Transform spawnPoint)
        {
            var player = Instantiate(prefab);
            player.position = spawnPoint.position;
            return player;
        }
    }
}
