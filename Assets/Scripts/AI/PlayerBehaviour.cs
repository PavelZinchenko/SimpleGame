using UnityEngine;
using UnityEngine.InputSystem;
using Characters;

namespace Ai
{
    [RequireComponent(typeof(PlayerStats))]
    public class PlayerBehaviour : MonoBehaviour, ICharacterBehaviour, StateMachine.Character.ICallback
    {
        [SerializeField] private StateMachine.Character.StateMachine _character;
        [SerializeField] private float _screenBorderSize = 2f;
        [SerializeField] private float _hitCooldown = 1f;

        private Camera _camera;
        private Vector2 _movingDirection;
        private float _lastHitTime;
        private PlayerStats _playerStats;

        private void Awake()
        {
            _camera = Camera.main;
            _playerStats = GetComponent<PlayerStats>();
            _character.SetCallback(this);
        }

        private void Update()
        {
            var position = transform.position;
            var direction = _movingDirection;
            ProcessBorders(position, ref direction);
            _character.Move(direction);
        }

        public void Die()
        {
            _character.Die();
        }

        public void Hit()
        {
            if (Time.time - _lastHitTime < _hitCooldown) return;
            _lastHitTime = Time.time;

            if (--_playerStats.Health > 0)
                _character.Hit();
            else
                _character.Die();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _movingDirection = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            var jump = context.ReadValueAsButton();
            _character.Jump(jump);
        }

        public void OnFellDown()
        {
        }

        public void OnDied()
        {
            _playerStats.Health = 0;
        }

        private void ProcessBorders(Vector2 position, ref Vector2 direction)
        {
            var cameraCenter = _camera.transform.position;
            var width = _camera.orthographicSize * _camera.aspect;
            var left = cameraCenter.x - width;
            var right = cameraCenter.x + width;

            if (position.x < left + _screenBorderSize)
                direction.x = Mathf.Lerp(direction.x, 1f, Mathf.Clamp01(left + _screenBorderSize - position.x));
            if (position.x > right - _screenBorderSize)
                direction.x = Mathf.Lerp(direction.x, -1f, Mathf.Clamp01(position.x - right + _screenBorderSize));
        }
    }
}

