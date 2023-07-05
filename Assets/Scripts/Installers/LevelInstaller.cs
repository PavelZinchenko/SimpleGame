using Zenject;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Installers
{
    public class LevelInstaller : MonoInstaller<LevelInstaller>
    {
        [SerializeField] private Tilemap _groundTilemap;
        [SerializeField] private Camera.CameraSelector _camera;

        public override void InstallBindings()
        {
            Container.Bind<Camera.CameraSelector>().FromInstance(_camera);
            Container.BindInterfacesAndSelfTo<LevelMap>().AsCached().WithArguments(_groundTilemap);
            Container.BindInterfacesAndSelfTo<Services.GameObjectFactory>().AsCached();
        }
    }
}
