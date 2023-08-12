using UnityEngine;
using Zenject;
using Characters;

public class PlayerSpawner : MonoBehaviour
{
    [Inject] private readonly Services.GameObjectFactory _objectFactory;

    [SerializeField] private PlayableCharacterData[] _characters;
    [SerializeField] private string _playerActionMap1 = "Player1";
    [SerializeField] private string _playerActionMap2 = "Player2";

    [SerializeField] private int _playerCharacterIndex1 = 0;
    [SerializeField] private int _playerCharacterIndex2 = 1;

    [SerializeField] private Gui.HitPoints _livesIndicator1;
    [SerializeField] private Gui.HitPoints _livesIndicator2;

    public PlayerPrefabInitializer SpawnPlayer1(Vector3 position)
    {
        var player = CreatePlayer(_playerCharacterIndex1, position);
        player.SetInputActionMap(_playerActionMap1);
        _livesIndicator1.SetCharacter(player.Stats);
        return player;
    }

    public PlayerPrefabInitializer SpawnPlayer2(Vector3 position)
    {
        var player = CreatePlayer(_playerCharacterIndex2, position);
        player.SetInputActionMap(_playerActionMap2);
        _livesIndicator2.SetCharacter(player.Stats);
        return player;
    }

    private PlayerPrefabInitializer CreatePlayer(int index, Vector3 spawnPoint)
    {
        var prefab = _characters[index].Prefab;
        var player = _objectFactory.Create(prefab);
        player.transform.position = spawnPoint;
        return player;
    }
}
