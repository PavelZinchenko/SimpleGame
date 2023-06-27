using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ICharacterAnimation))]
public class Character : MonoBehaviour
{
    [SerializeField] private Transform _feet;

    [Range(1, 100)][SerializeField] private float _movementSpeed = 5f;
    [Range(1, 500)][SerializeField] private float _jumpSpeed = 8f;
    [Range(1, 500)][SerializeField] private float _gravity = 20f;
    [Range(10f, 1000f)][SerializeField] private float _acceleration = 300f;
    [SerializeField] private bool _airControl = false;

    [SerializeField] private UnityEvent _jumpEvent = new();
    //[SerializeField] private UnityEvent _hitEvent = new();

    private Rigidbody2D _rigidbody2D;
    private ICharacterAnimation _animation;

    private Vector2 _movementDirection;
    private bool _wantToJump;
    private bool _jumping;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animation = GetComponent<ICharacterAnimation>();
    }

    private void FixedUpdate()
    {
        var velocity = _rigidbody2D.velocity;
        var targetVelocity = _movementDirection * _movementSpeed;

        if (_wantToJump && !_jumping)
            StartCoroutine(DoJump());

        if (_airControl || !_jumping)
            _rigidbody2D.AddForce((targetVelocity - velocity) * Time.fixedDeltaTime * _acceleration);

        _animation.Walk(velocity / _movementSpeed);
    }

    public void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    public void Jump(bool pressed)
    {
        _wantToJump = pressed;
    }

    private IEnumerator DoJump()
    {
        if (_jumping) yield break;
        _jumping = true;
        _jumpEvent?.Invoke();

        var initialPosition = _feet.transform.localPosition;
        var position = initialPosition;
        var speed = _jumpSpeed;

        do
        {
            position.y += speed * Time.deltaTime;
            speed -= _gravity * Time.deltaTime;
            _feet.transform.localPosition = position;
            _animation.Jump(speed, false);
            yield return null;
        }
        while (position.y > initialPosition.y);

        _feet.transform.localPosition = initialPosition;
        _animation.Jump(0, true);
        _jumping = false;
    }
}
