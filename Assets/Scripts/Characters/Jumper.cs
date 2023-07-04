//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;

//namespace Characters
//{
//    [RequireComponent(typeof(ICharacterAnimation))]
//    public class Jumper : MonoBehaviour
//    {
//        [SerializeField] private LayerMask _groundLayerMask;
//        [SerializeField] private float _gravity = 10;
//        [SerializeField] private float _jumpSpeed = 5;
//        [SerializeField] private float _bottomAltitude = -10;

//        [SerializeField] private UnityEvent _tookOff = new();
//        [SerializeField] private UnityEvent _landed = new();
//        [SerializeField] private UnityEvent _fellAndDied = new();

//        private bool _hasGround;
//        private bool _coroutineRunning;
//        private float _speed;
//        private float _altitude;
//        private HashSet<Collider2D> _activeColliders = new();
//        private ICharacterAnimation _animation;

//        public bool Standing => _altitude <= 0 && _hasGround;

//        private void Awake()
//        {
//            _animation = GetComponent<ICharacterAnimation>();
//        }

//        private void Start()
//        {
//            if (_altitude > 0)
//                StartCoroutine(StartSimulation());
//        }

//        private void OnTriggerStay2D(Collider2D collision)
//        {
//            Debug.Log("OnTriggerExit2D: " + collision.name);
//        }

//        private void OnTriggerEnter2D(Collider2D collision)
//        {
//            Debug.Log("OnTriggerEnter2D: " + collision.name);

//            if (_activeColliders.Add(collision))
//                OnCollidersChanged();
//        }

//        private void OnTriggerExit2D(Collider2D collision)
//        {
//            Debug.Log("OnTriggerExit2D: " + collision.name);

//            if (_activeColliders.Remove(collision))
//                OnCollidersChanged();
//        }

//        private void OnCollidersChanged()
//        {
//            _hasGround = _activeColliders.Count > 0;

//            if (!_hasGround && !_coroutineRunning)
//                StartCoroutine(StartSimulation());
//        }

//        public void Jump()
//        {
//            if (!Standing) return;
            
//            _speed = _jumpSpeed;
//            if (!_coroutineRunning)
//                StartCoroutine(StartSimulation());
//        }

//        private IEnumerator StartSimulation()
//        {
//            if (_coroutineRunning) yield break;
//            _coroutineRunning = true;

//            _tookOff.Invoke();
//            _animation.Jump(_speed, false);

//            bool finished = false;
//            while (!finished)
//            {
//                _speed -= _gravity * Time.deltaTime;
//                _altitude += _speed * Time.deltaTime;
//                _animation.Jump(_speed, false);

//                if (Standing)
//                {
//                    _altitude = 0;
//                    finished = true;
//                    _landed.Invoke();
//                    _animation.Jump(0, true);
//                }
//                else if (_altitude < _bottomAltitude)
//                {
//                    finished = true;
//                    _fellAndDied.Invoke();
//                }

//                var position = transform.localPosition;
//                position.y = _altitude;
//                transform.localPosition = position;

//                if (!finished)
//                    yield return null;
//            }

//            _speed = 0;
//            _coroutineRunning = false;
//        }
//    }
//}
