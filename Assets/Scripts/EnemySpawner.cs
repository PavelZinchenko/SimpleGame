using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _positions = { };

    [Inject] private Services.GameObjectFactory _objectFactory;

    public void Spawn()
    {
        foreach (var point in _positions)
        {
            var instance = _objectFactory.Create(_prefab);
            instance.transform.position = point.position;
        }
    }
}
