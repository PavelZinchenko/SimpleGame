using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ui
{
    public class HitPoints : MonoBehaviour
    {
        [SerializeField] private List<HeartIcon> _hearts = new();

        private void Start()
        {
            StartCoroutine(DecreaseHitPoints());
        }

        private IEnumerator DecreaseHitPoints()
        {
            yield return new WaitForSeconds(5f);

            while (true)
            {
                for (var i = 4; i >= 0; i--)
                {
                    _hearts[i].SetVisible(false);
                    yield return new WaitForSeconds(0.3f);
                }

                for (var i = 0; i < 5; i++)
                {
                    _hearts[i].SetVisible(true);
                    yield return new WaitForSeconds(0.3f);
                }
            }
        }

        public void SetValue(int hitpoints)
        {
            for (var i = 0; i < _hearts.Count; ++i)
                _hearts[i].SetVisible(i < hitpoints);
        }
    }
}
