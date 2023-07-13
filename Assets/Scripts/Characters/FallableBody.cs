using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Characters
{
    public class FallableBody : MonoBehaviour
    {
        [SerializeField] private float _gravity = 20f;
        [SerializeField] private float _groundAltitude = 0f;
        [SerializeField] private float _minAltitude = -20f;

        [SerializeField] private UnityEvent<float> _altitudeChanged;
        [SerializeField] private UnityEvent<float> _speedChanged;
        [SerializeField] private UnityEvent _jumped;
        [SerializeField] private UnityEvent _landed;
        [SerializeField] private UnityEvent _fallingUnderground;

        private bool _isRunning;
        private bool _hasGround = true;
        private float _altitude;
        private float _speed;

        public event UnityAction<float> AltitudeChanged
        {
            add => (_altitudeChanged ??= new()).AddListener(value);
            remove => _altitudeChanged.RemoveListener(value);
        }

        public event UnityAction<float> SpeedChanged
        {
            add => (_speedChanged ??= new()).AddListener(value);
            remove => _speedChanged.RemoveListener(value);
        }

        public event UnityAction Jumped
        {
            add => (_jumped ??= new()).AddListener(value);
            remove => _jumped.RemoveListener(value);
        }

        public event UnityAction Landed
        {
            add => (_landed ??= new()).AddListener(value);
            remove => _landed.RemoveListener(value);
        }

        public event UnityAction FallingUnderground
        {
            add => (_fallingUnderground ??= new()).AddListener(value);
            remove => _fallingUnderground.RemoveListener(value);
        }

        public bool IsStanding => !_isRunning;
        public bool IsAboveGround => _altitude >= _groundAltitude;

        public float Altitude
        {
            get => _altitude;
            set
            {
                _altitude = value;
                UpdateAltitude();
                EnsureCoroutineRunning();
            }
        }

        public float Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                EnsureCoroutineRunning();
            }
        }
        
        public bool HasGround
        {
            get => _hasGround;
            set
            {
                if (_hasGround == value) return;
                _hasGround = value;
                if (!_hasGround) 
                    EnsureCoroutineRunning();
            }
        }

        private void Start()
        {
            Altitude = transform.localPosition.y;
        }

        private IEnumerator StartSimulation()
        {
            if (_isRunning) yield break;
            _isRunning = true;

            _jumped?.Invoke();

            bool finished = false;
            while (!finished)
            {
                var wasAboveGround = _altitude >= _groundAltitude;
                _speed -= _gravity * Time.deltaTime;
                _altitude += _speed * Time.deltaTime;
                var fallingUnderground = _altitude < _groundAltitude;

                if (wasAboveGround && fallingUnderground && HasGround)
                {
                    _altitude = _groundAltitude;
                    finished = true;
                }
                else if (wasAboveGround && fallingUnderground)
                {
                    _fallingUnderground?.Invoke();
                }
                else if (_altitude <= _minAltitude)
                {
                    _altitude = _minAltitude;
                    finished = true;
                }

                UpdateAltitude();
                _speedChanged?.Invoke(_speed);

                if (!finished)
                    yield return null;
            }

            _speed = 0f;
            _isRunning = false;

            _landed?.Invoke();
        }

        private void EnsureCoroutineRunning()
        {
            if (!_isRunning)
                StartCoroutine(StartSimulation());
        }

        private void UpdateAltitude()
        {
            var position = transform.localPosition;
            position.y = _altitude;
            transform.localPosition = position;

            _altitudeChanged?.Invoke(_altitude);
        }
    }
}
