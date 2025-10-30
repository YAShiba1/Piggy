using UnityEngine;

[RequireComponent(typeof(Flipper))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _playerDetectionRange;

    private Flipper _flipper;

    private Transform[] _points;
    private int _currentPoint;

    private float _targetReachedThreshold = 0.1f;

    private void Start()
    {
        _flipper = GetComponent<Flipper>();

        InitializePatrolPoints();
    }

    private void Update()
    {
        if (IsNearTarget(_player, _playerDetectionRange))
        {
            MoveHorizontallyTowards(_player);
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        Transform target = _points[_currentPoint];

        MoveHorizontallyTowards(target);

        if (IsNearTarget(target, _targetReachedThreshold))
        {
            _currentPoint++;

            _flipper.Flip();

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void LookAtTarget(Transform target)
    {
        if (target.position.x > transform.position.x && !_flipper.IsFacingRight)
        {
            _flipper.Flip();
        }
        else if (target.position.x < transform.position.x && _flipper.IsFacingRight)
        {
            _flipper.Flip();
        }
    }

    private void InitializePatrolPoints()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void MoveHorizontallyTowards(Transform target)
    {
        Vector2 horizontalTarget = new(target.position.x, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, horizontalTarget, _speed * Time.deltaTime);

        LookAtTarget(target);
    }

    private bool IsNearTarget(Transform target, float threshold)
    {
        return Vector2.Distance(transform.position, target.position) < threshold;
    }
}
