using UnityEngine;
using UnityEngine.Events;

public class TriggerDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private UnityEvent _triggerEnter = new();

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!_layerMask.Contains(collider.gameObject.layer)) return;
        _triggerEnter.Invoke();
    }
}
