using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ICharacterAnimation))]
public class Character : MonoBehaviour
{
    [SerializeField] private Transform _body;

    [Range(1, 100)][SerializeField] private float _movementSpeed = 5f;
    [Range(1, 500)][SerializeField] private float _jumpSpeed = 8f;
    [Range(1, 500)][SerializeField] private float _gravity = 20f;
    [Range(10f, 1000f)][SerializeField] private float _acceleration = 300f;
    [SerializeField] private bool _airControl = false;

    [SerializeField] private UnityEvent _jumped = new();
    [SerializeField] private UnityEvent _lostGround = new();
    [SerializeField] private UnityEvent _gotBackToGround = new();

    private Rigidbody2D _rigidbody2D;
    private ICharacterAnimation _animation;

    private Vector2 _movementDirection;
    private bool _wantToJump;
    private bool _grounded = true;

    public bool Grounded
    {
        get => _grounded;
        private set
        {
            if (_grounded == value) return;
            _grounded = value;

            if (_grounded)
                _gotBackToGround?.Invoke();
            else
                _lostGround?.Invoke();
        }
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animation = GetComponent<ICharacterAnimation>();
    }

    private void FixedUpdate()
    {
        var velocity = _rigidbody2D.velocity;
        var targetVelocity = _movementDirection * _movementSpeed;

        if (_wantToJump && Grounded)
            StartCoroutine(DoJump());

        if (_airControl || Grounded)
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

    public void FallDown()
    {
        StartCoroutine(FallDownAndDie());
    }

    private IEnumerator DoJump()
    {
        if (!Grounded) yield break;
        Grounded = false;
        _jumped?.Invoke();

        var initialPosition = _body.transform.localPosition;
        var position = initialPosition;
        var speed = _jumpSpeed;

        do
        {
            position.y += speed * Time.deltaTime;
            speed -= _gravity * Time.deltaTime;
            _body.transform.localPosition = position;
            _animation.Jump(speed, false);
            yield return null;
        }
        while (position.y > initialPosition.y);

        _body.transform.localPosition = initialPosition;
        _animation.Jump(0, true);
        Grounded = true;
    }

    private IEnumerator FallDownAndDie()
    {
        if (!Grounded) yield break;
        Grounded = false;
        _animation.Jump(-1, false);

        _rigidbody2D.gravityScale = 1f;
        _airControl = false;

        while (transform.position.y > -10)
        {
            yield return null;
        }

        Destroy(gameObject);
    }
}
