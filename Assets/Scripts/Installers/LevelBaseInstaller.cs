using Zenject;
using UnityEngine;

namespace Installers
{
    public class LevelBaseInstaller : MonoInstaller<LevelBaseInstaller>
    {
        [SerializeField] private Settings.Characters _characters;
        [SerializeField] private Settings.PlayerWallet _playerWallet;
        [SerializeField] private Gui.WalletPanel _wallet;
        [SerializeField] private Gui.GameOverPanel _gameOverPanel;
        [SerializeField] private CharacterSpawner _characterSpawner;

        public override void InstallBindings()
        {
            Container.Bind<Settings.Characters>().FromInstance(_characters);
            Container.Bind<Settings.PlayerWallet>().FromInstance(_playerWallet);
            Container.Bind<Gui.WalletPanel>().FromInstance(_wallet);
            Container.Bind<Gui.GameOverPanel>().FromInstance(_gameOverPanel);
            Container.Bind<CharacterSpawner>().FromInstance(_characterSpawner);
        }
    }
}
