using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private readonly List<Transform> _targets = new();

    public float FixedSpeedX { get; set; }
    public bool TrackingDisabled { get; set; }

    private void Update()
    {
        var cameraPosition = transform.localPosition;

        if (TrackingDisabled || !TryGetTargetPosition(out var targetPosition))
            targetPosition = cameraPosition;

        var fixedX = cameraPosition.x + FixedSpeedX * Time.deltaTime;
        var targetX = Mathf.Lerp(cameraPosition.x, targetPosition.x, Time.deltaTime * _speed);

        if (FixedSpeedX >= 0)
            cameraPosition.x = Mathf.Max(fixedX, targetX);
        else
            cameraPosition.x = Mathf.Min(fixedX, targetX);

        transform.localPosition = cameraPosition;
    }

    public void TrackTarget(GameObject target)
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
            position.y += targetPosition.y;
        }

        if (targetCount == 0) 
            return false;

        position.x /= targetCount;
        position.y /= targetCount;

        return true;
    }
}
