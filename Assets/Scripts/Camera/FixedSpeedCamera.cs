using UnityEngine;

namespace Camera
{
    public class FixedSpeedCamera : MonoBehaviour
    {
        [SerializeField] private float _speed = 2;

        private void Update()
        {
            var position = transform.localPosition;
            position.x += Time.deltaTime * _speed;
            transform.localPosition = position;
        }
    }
}
