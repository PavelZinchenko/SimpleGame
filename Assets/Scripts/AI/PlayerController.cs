using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Characters.CharacterStateMachine _character;

    private Vector2 _movingDirection;

    private Transform _leftBorder;
    private Transform _rightBorder;

    private void Update()
    {
        var direction = _movingDirection;
        var x = transform.position.x;

        if (_leftBorder)
        {
            var borderX = _leftBorder.position.x;
            if (x < borderX)
                direction.x = Mathf.Lerp(direction.x, 1f, Mathf.Clamp01(borderX - x));
        }

        if (_rightBorder)
        {
            var borderX = _rightBorder.position.x;
            if (x > borderX)
                direction.x = Mathf.Lerp(direction.x, -1f, Mathf.Clamp01(x - borderX));
        }

        _character.Move(direction);
    }

    public void SetBorders(Transform leftBorder, Transform rightBorder)
    {
        _leftBorder = leftBorder;
        _rightBorder = rightBorder;
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
}
