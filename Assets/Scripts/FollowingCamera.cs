using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 10;
    [SerializeField] private bool _automatic;

    private void Update()
    {
        var position = transform.localPosition;

        if (_automatic)
            position.x += Time.deltaTime * _speed;
        else if (_target)
            position.x = Mathf.Lerp(position.x, _target.position.x, Time.deltaTime * _speed);
        else
            return;

        transform.localPosition = position;
    }
}
