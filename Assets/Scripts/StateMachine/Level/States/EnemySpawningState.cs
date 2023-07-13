using UnityEngine;
using Zenject;

namespace StateMachine.Level.States
{
    public class EnemySpawningState : Base.State<Context>
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private Transform[] _spawnPoints = { };

        [Inject] private readonly Services.GameObjectFactory _objectFactory;

        private void OnEnable()
        {
            foreach (var point in _spawnPoints)
                CreateEnemy(_enemyPrefab, point);
        }

        private void CreateEnemy(GameObject prefab, Transform spawnPoint)
        {
            var enemy = _objectFactory.Create(prefab);
            enemy.transform.position = spawnPoint.position;
        }
    }
}
