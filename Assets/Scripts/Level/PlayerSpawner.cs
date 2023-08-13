using UnityEngine;
using Zenject;
using Characters;

public class PlayerSpawner : MonoBehaviour
{
    [Inject] private readonly Services.GameObjectFactory _objectFactory;
    [Inject] private readonly Model.GameSettings _gameSettings;

    [SerializeField] private string _playerActionMap1 = "Player1";
    [SerializeField] private string _playerActionMap2 = "Player2";

    [SerializeField] private Gui.HitPoints _livesIndicator1;
    [SerializeField] private Gui.HitPoints _livesIndicator2;

    public PlayerPrefabInitializer SpawnPlayer1(Vector3 position)
    {
        var character = _gameSettings.GetPlayer1Character();
        if (character == null)
        {
            _livesIndicator1.gameObject.SetActive(false);
            return null;
        }

        var player = CreatePlayer(character, position);
        player.SetInputActionMap(_playerActionMap1);
        _livesIndicator1.SetCharacter(player.Stats);
        return player;
    }

    public PlayerPrefabInitializer SpawnPlayer2(Vector3 position)
    {
        var character = _gameSettings.GetPlayer2Character();
        if (character == null)
        {
            _livesIndicator2.gameObject.SetActive(false);
            return null;
        }

        var player = CreatePlayer(character, position);
        player.SetInputActionMap(_playerActionMap2);
        _livesIndicator2.SetCharacter(player.Stats);
        return player;
    }

    private PlayerPrefabInitializer CreatePlayer(PlayableCharacterData data, Vector3 spawnPoint)
    {
        var prefab = data.Prefab;
        var player = _objectFactory.Create(prefab);
        player.transform.position = spawnPoint;
        return player;
    }
}
