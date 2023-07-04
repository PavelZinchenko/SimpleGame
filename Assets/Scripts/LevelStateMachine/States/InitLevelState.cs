﻿using UnityEngine;

namespace LevelStateMachine.States
{
    public class InitLevelState : State
    {
        [SerializeField] private PlayerController _playerPrefab1;
        [SerializeField] private PlayerController _playerPrefab2;
        [SerializeField] private Transform _leftBorder;
        [SerializeField] private Transform _rightBorder;

        [SerializeField] private Transform _spawnPoint1;
        [SerializeField] private Transform _spawnPoint2;
        [SerializeField] private Camera.FollowCamera _camera;

        private void OnEnable()
        {
            var player1 = CreatePlayer(_playerPrefab1, _spawnPoint1);
            var player2 = CreatePlayer(_playerPrefab2, _spawnPoint2);

            player1.SetBorders(_leftBorder, _rightBorder);
            player2.SetBorders(_leftBorder, _rightBorder);

            _camera.Initialize(player1.transform, player2.transform);
        }

        private static PlayerController CreatePlayer(PlayerController prefab, Transform spawnPoint)
        {
            var player = Instantiate(prefab);
            player.transform.position = spawnPoint.position;
            return player;
        }
    }
}
