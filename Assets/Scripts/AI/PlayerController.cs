using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private StateMachine.Character.StateMachine _character;
    [SerializeField] private float _screenBorderSize = 2f;

    private Vector2 _movingDirection;

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

    public void OnMove(InputAction.CallbackContext context)
    {
        _movingDirection = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        var jump = context.ReadValueAsButton();
        _character.Jump(jump);
    }

    private void ProcessBorders(Vector2 position, ref Vector2 direction)
    {
        var camera = UnityEngine.Camera.main;
        var cameraCenter = camera.transform.position;
        var width = camera.orthographicSize * camera.aspect;
        var left = cameraCenter.x - width;
        var right = cameraCenter.x + width;

        if (position.x < left + _screenBorderSize)
            direction.x = Mathf.Lerp(direction.x, 1f, Mathf.Clamp01(left + _screenBorderSize - position.x));
        if (position.x > right - _screenBorderSize)
            direction.x = Mathf.Lerp(direction.x, -1f, Mathf.Clamp01(position.x - right + _screenBorderSize));
    }
}
