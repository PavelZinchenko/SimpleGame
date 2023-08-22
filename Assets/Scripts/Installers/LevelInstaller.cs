using Zenject;
using UnityEngine;

namespace Installers
{
    public class LevelInstaller : MonoInstaller<LevelInstaller>
    {
        [SerializeField] private CameraController _camera;
        [SerializeField] private Level.LevelMap _levelMap;

        public override void InstallBindings()
        {
            Container.Bind<CameraController>().FromInstance(_camera);
            Container.Bind<Level.ILevelMap>().FromInstance(_levelMap);
        }
    }
}
