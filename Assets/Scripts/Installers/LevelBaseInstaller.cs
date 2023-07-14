using Zenject;
using UnityEngine;

namespace Installers
{
    public class LevelBaseInstaller : MonoInstaller<LevelBaseInstaller>
    {
        [SerializeField] private PlayerSpawner _playerSpawner;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Services.GameObjectFactory>().AsCached();
            Container.BindInterfacesAndSelfTo<LevelMap>().AsSingle();
            Container.Bind<PlayerSpawner>().FromInstance(_playerSpawner);
        }
    }
}
