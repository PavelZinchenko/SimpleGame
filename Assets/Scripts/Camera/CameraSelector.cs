using UnityEngine;

namespace Camera
{
    public enum CameraMode
    {
        Static,
        FixedSpeed,
        Follow,
    }

    public class CameraSelector : MonoBehaviour
    {
        [SerializeField] private FixedSpeedCamera _fixedSpeedCamera;
        [SerializeField] private FollowCamera _followCamera;

        public void SetStaticCamera() => Select(CameraMode.Static);
        public void SetFixedSpeedCamera() => Select(CameraMode.FixedSpeed);
        public void SetFollowCamera() => Select(CameraMode.Follow);

        public void Select(CameraMode mode)
        {
            _fixedSpeedCamera.enabled = mode == CameraMode.FixedSpeed;
            _followCamera.enabled = mode == CameraMode.Follow;
        }
    }
}
