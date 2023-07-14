using UnityEngine;
using Zenject;
using Ai;

public class PlayerSpawner : MonoBehaviour
{
    [Inject] private readonly Services.GameObjectFactory _objectFactory;

    [SerializeField] private Characters.PlayableCharacterData[] _characters;
    [SerializeField] private string _playerActionMap1 = "Player1";
    [SerializeField] private string _playerActionMap2 = "Player2";

    [SerializeField] private int _playerCharacterIndex1 = 0;
    [SerializeField] private int _playerCharacterIndex2 = 1;

    public void SpawnPlayer1(Vector3 position)
    {
        var player = CreatePlayer(_playerCharacterIndex1, position);
        player.SetInputActionMap(_playerActionMap1);
    }

    public void SpawnPlayer2(Vector3 position)
    {
        var player = CreatePlayer(_playerCharacterIndex2, position);
        player.SetInputActionMap(_playerActionMap2);
    }

    private PlayerBehaviour CreatePlayer(int index, Vector3 spawnPoint)
    {
        var prefab = _characters[index].Prefab;
        var player = _objectFactory.Create(prefab);
        player.transform.position = spawnPoint;
        return player;
    }
}
