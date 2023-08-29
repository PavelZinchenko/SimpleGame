using System.Collections;
using UnityEngine;

namespace Level
{
    public class DelayedKiller : MonoBehaviour
    {
        [SerializeField] private float _delay;

        public void Kill()
        {
            StartCoroutine(WaitThenDestroy());
        }

        private IEnumerator WaitThenDestroy()
        {
            yield return new WaitForSeconds(_delay);
            Destroy(gameObject);
        }
    }
}
