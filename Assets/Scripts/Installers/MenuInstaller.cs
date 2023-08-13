using Zenject;
using UnityEngine;

namespace Installers
{
    public class MenuInstaller : MonoInstaller<MenuInstaller>
    {
        [SerializeField] private Model.GameSettings _gameSettings;

        public override void InstallBindings()
        {
            Container.Bind<Model.GameSettings>().FromInstance(_gameSettings);
        }
    }
}
