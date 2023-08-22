using Zenject;

namespace StateMachine.Level.States
{
    public class GameOverState : Base.State<Context>
    {
        [Inject] private readonly Gui.GameOverPanel _gameOverPanel;

        private void OnEnable()
        {
            _gameOverPanel.Show();
        }
    }
}
