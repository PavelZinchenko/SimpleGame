using System.Collections;
using UnityEngine;

public class DelayedKiller : MonoBehaviour
{
    [SerializeField] private float _delay;

    private bool _started;

    public void Kill()
    {
        StartCoroutine(WaitThenDestroy());
    }

    private IEnumerator WaitThenDestroy()
    {
        if (_started) yield break;
        _started = true;

        yield return new WaitForSeconds(_delay);
        Destroy(gameObject);
    }
}
