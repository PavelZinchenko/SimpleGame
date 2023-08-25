using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _scaleY = 0.5f;

    private readonly List<Transform> _targets = new();

    public float FixedSpeedX { get; set; }
    public bool TrackingDisabled { get; set; }
    public void Freeze() => enabled = false;
    public void Unfreeze() => enabled = true;

    private void Update()
    {
        var cameraPosition = transform.localPosition;

        if (TrackingDisabled || !TryGetTargetPosition(out var targetPosition))
            targetPosition = cameraPosition;

        var fixedX = cameraPosition.x + FixedSpeedX * Time.deltaTime;
        var target = Vector2.Lerp(cameraPosition, targetPosition, Time.deltaTime * _speed);

        cameraPosition.y = target.y;
        cameraPosition.x = FixedSpeedX >= 0 ? Mathf.Max(fixedX, target.x) : Mathf.Min(fixedX, target.x);
        transform.localPosition = cameraPosition;
    }

    public void TrackTarget(Component target)
    {
        _targets.Add(target.transform);
    }

    private bool TryGetTargetPosition(out Vector2 position)
    {
        position = Vector2.zero;
        int targetCount = 0;
        foreach (var item in _targets)
        {
            if (!item) continue;
            targetCount++;
            var targetPosition = item.position;
            position.x += targetPosition.x;
            position.y += targetPosition.y * _scaleY;
        }

        if (targetCount == 0) 
            return false;

        position.x /= targetCount;
        position.y /= targetCount;

        return true;
    }
}
