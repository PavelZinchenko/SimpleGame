using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SimpleEnemyController : MonoBehaviour
{
    [SerializeField] private Characters.CharacterStateMachine _character;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private Transform _feet;

    [Inject] private readonly LevelMap _levelMap;

    private List<Transform> _targets = new();
    private bool _chasing;

    private void Update()
    {
        var position = transform.position;
        var cell = _levelMap.WorldToCell(position);
        _character.Grounded = _levelMap.HasTile(cell);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_targetMask.Contains(collision.gameObject.layer))
            _targets.Add(collision.transform);

        if (!_chasing)
            StartCoroutine(StartChasing());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_targetMask.Contains(collision.gameObject.layer))
            _targets.Remove(collision.transform);
    }

    private IEnumerator StartChasing()
    {
        if (_chasing) yield break;
        _chasing = true;

        while (true)
        {
            Vector2 position = _feet.position;
            var target = GetClosestTarget(position);
            if (target == null) break;
            
            var targetPosition = (Vector2)target.position;
            _character.Move((targetPosition - position).normalized);
            yield return null;
        }

        _character.Move(Vector2.zero);
        _chasing = false;
    }

    private Transform GetClosestTarget(Vector2 position)
    {
        Transform target = null;
        var minDistance = float.MaxValue;

        foreach (var item in _targets)
        {
            var targetPosition = (Vector2)item.position;
            var sqrDistance = Vector2.SqrMagnitude(position - targetPosition);
            if (sqrDistance < minDistance)
            {
                minDistance = sqrDistance;
                target = item;
            }
        }

        return target;
    }
}
