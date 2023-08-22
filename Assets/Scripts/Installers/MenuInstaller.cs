using Zenject;
using UnityEngine;

namespace Installers
{
    public class MenuInstaller : MonoInstaller<MenuInstaller>
    {
        [SerializeField] private Settings.Characters _characters;
        [SerializeField] private Settings.PlayerWallet _wallet;

        public override void InstallBindings()
        {
            Container.Bind<Settings.Characters>().FromInstance(_characters);
            Container.Bind<Settings.PlayerWallet>().FromInstance(_wallet);
        }
    }
}
