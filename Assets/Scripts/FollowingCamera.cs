using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 10;

    private void Update()
    {
        var position = transform.localPosition;
        position.x = Mathf.Lerp(position.x, _target.position.x, Time.deltaTime * _speed);
        transform.localPosition = position;
    }
}
