using System.Collections.Generic;
using UnityEngine;

namespace Camera
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private float _speed = 2;

        private readonly List<Transform> _targets = new();

        public void Initialize(params Transform[] players)
        {
            _targets.Clear();
            _targets.AddRange(players);
        }

        private void Update()
        {
            float targetX = 0;
            int targetCount = 0;

            foreach (var item in _targets)
            {
                if (!item) continue;
                targetCount++;
                targetX += item.position.x;
            }

            if (targetCount == 0) return;

            targetX /= targetCount;
            var position = transform.localPosition;

            if (position.x > targetX) return;

            position.x = Mathf.Lerp(position.x, targetX, Time.deltaTime * _speed);
            transform.localPosition = position;
        }
    }
}
