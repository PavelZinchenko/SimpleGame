using UnityEngine;

namespace GameStateMachine.States
{
    public class SpawnEnemyState : State
    {
        [SerializeField] private Transform _enemyPrefab;
        [SerializeField] private Transform[] _spawnPoints = {};

        private void OnEnable()
        {
            foreach (var point in _spawnPoints)
                CreateEnemy(_enemyPrefab, point);
        }

        private static void CreateEnemy(Transform prefab, Transform spawnPoint)
        {
            var enemy = Instantiate(prefab);
            enemy.position = spawnPoint.position;
        }
    }
}
