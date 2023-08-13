using UnityEngine;
using UnityEngine.Events;

namespace Gui
{
    public class StartEventCaller : MonoBehaviour
    {
        [SerializeField] private UnityEvent SceneStarted;

        private void Start()
        {
            SceneStarted?.Invoke();
        }
    }
}
