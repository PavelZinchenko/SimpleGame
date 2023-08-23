using System.Collections;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [Inject] private readonly CharacterSpawner _characterSpawner;

    [SerializeField] private Characters.CharacterConfigurator _prefab;
    [SerializeField] private Transform[] _positions = { };
    [SerializeField] private float _delay;

    public void Spawn()
    {
        StartCoroutine(SpawnEnemies());
    }

    public IEnumerator SpawnEnemies()
    {
        var waiter = _delay > 0 ? new WaitForSeconds(_delay) : null;

        foreach (var point in _positions)
        {
            _characterSpawner.Spawn(_prefab, point.position);
            yield return waiter;
        }
    }
}
