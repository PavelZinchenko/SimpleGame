using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;

    [SerializeField] private UnityEvent _leftGround = new();
    [SerializeField] private UnityEvent _steppedOnGround = new();

    private bool _grounded;
    private HashSet<Collider2D> _activeColliders = new();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_activeColliders.Add(collision))
            OnCollidersChanged();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_activeColliders.Remove(collision))
            OnCollidersChanged();
    }

    private void OnCollidersChanged()
    {
        var grounded = _activeColliders.Count > 0;
        if (_grounded == grounded) return;

        _grounded = grounded;
        if (_grounded)
            _steppedOnGround.Invoke();
        else
            _leftGround.Invoke();
    }
}
