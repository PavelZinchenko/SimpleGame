using Zenject;
using UnityEngine;

namespace Installers
{
    public class LevelInstaller : MonoInstaller<LevelInstaller>
    {
        [SerializeField] private GameLevel.CameraController _camera;
        [SerializeField] private GameLevel.LevelMap _levelMap;

        public override void InstallBindings()
        {
            Container.Bind<GameLevel.CameraController>().FromInstance(_camera);
            Container.Bind<GameLevel.ILevelMap>().FromInstance(_levelMap);
        }
    }
}
