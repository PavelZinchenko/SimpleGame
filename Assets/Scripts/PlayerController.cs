using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Character))]
public class PlayerController : MonoBehaviour
{
    private Character _character;

    private void Awake()
    {
        _character = GetComponent<Character>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        _character.Move(direction);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        var jump = context.ReadValueAsButton();
        _character.Jump(jump);
    }
}
