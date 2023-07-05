using UnityEngine;
using Zenject;

namespace Services
{
    public class GameObjectFactory
    {
        [Inject] private readonly DiContainer _container;

        public GameObject Create(GameObject prefab, Transform parent = null)
        {
            return _container.InstantiatePrefab(prefab, parent);
        }

        public T Create<T>(T prefab, Transform parent = null) where T : Component
        {
            return _container.InstantiatePrefabForComponent<T>(prefab, parent);
        }
    }
}
