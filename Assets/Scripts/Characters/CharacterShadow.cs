using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CharacterShadow : MonoBehaviour
    {
        [SerializeField] private float _maxAltitude = 20;
        [SerializeField] private Transform _body;

        private SpriteRenderer _spriteRenderer;
        private Color _defaultColor;

        public void SetAltitude(float altitude)
        {
            SetOpacity(altitude < 0 ? 0 : (_maxAltitude - altitude) / _maxAltitude);
        }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _defaultColor = _spriteRenderer.color;
        }

        private void SetOpacity(float opacity)
        {
            _spriteRenderer.color = new Color(_defaultColor.r, _defaultColor.g, _defaultColor.b, _defaultColor.a * Mathf.Clamp01(opacity));
        }
    }
}
