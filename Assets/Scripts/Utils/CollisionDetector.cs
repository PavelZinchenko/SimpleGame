using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private UnityEvent _collisionEnter = new();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProcessCollision(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        ProcessCollision(collision);
    }

    private void ProcessCollision(Collision2D collision)
    {
        if (!_layerMask.Contains(collision.collider.gameObject.layer)) return;
        _collisionEnter.Invoke();
    }
}
