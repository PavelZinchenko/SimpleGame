using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [Inject] private readonly CharacterSpawner _characterSpawner;

    [SerializeField] private Characters.CharacterConfigurator _prefab;
    [SerializeField] private Transform[] _positions = { };

    public void Spawn()
    {
        foreach (var point in _positions)
            _characterSpawner.Spawn(_prefab, point.position);
    }
}
