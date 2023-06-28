using UnityEngine;
using UnityEngine.Events;

public class HoleDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _holeLayerMask;
    [SerializeField] private UnityEvent _steppedInHole = new();

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!_holeLayerMask.Contains(collider.gameObject.layer)) return;
        _steppedInHole.Invoke();
    }
}
