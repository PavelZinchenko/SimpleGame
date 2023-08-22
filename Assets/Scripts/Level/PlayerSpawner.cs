using UnityEngine;
using Zenject;
using Characters;

public class PlayerSpawner : MonoBehaviour
{
    [Inject] private readonly Settings.Characters _playerSettings;
    [Inject] private readonly CharacterSpawner _characterSpawner;

    [SerializeField] private string _playerActionMap1 = "Player1";
    [SerializeField] private string _playerActionMap2 = "Player2";

    [SerializeField] private Transform _spawnPoint1;
    [SerializeField] private Transform _spawnPoint2;

    public void Spawn()
    {
        SpawnPlayer(Settings.PlayerId.Player1, _spawnPoint1.position);
        SpawnPlayer(Settings.PlayerId.Player2, _spawnPoint2.position);
    }

    public CharacterConfigurator SpawnPlayer(Settings.PlayerId playerId, Vector3 position)
    {
        var character = _playerSettings.GetPlayerCharacter(playerId);
        if (character == null) 
            return null;

        var player = _characterSpawner.Spawn(character.Prefab, position);
        player.SetInputActionMap(GetActionMap(playerId));
        return player;
    }

    private string GetActionMap(Settings.PlayerId playerId)
    {
        switch (playerId)
        {
            case Settings.PlayerId.Player1: return _playerActionMap1;
            case Settings.PlayerId.Player2: return _playerActionMap2;
            default: return null;
        }
    }
}
