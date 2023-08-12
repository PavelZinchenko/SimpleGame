using Zenject;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Installers
{
    public class LevelInstaller : MonoInstaller<LevelInstaller>
    {
        [Inject] private LevelMap _levelMap;

        [SerializeField] private Tilemap _groundTilemap;
        [SerializeField] private CameraController _camera;

        public override void InstallBindings()
        {
            Container.Bind<CameraController>().FromInstance(_camera);
            
            _levelMap.SetGroundMap(_groundTilemap);
        }
    }
}
