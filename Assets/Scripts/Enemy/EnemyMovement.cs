using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _movement;
    private Transform _targetTransform;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetupTarget(Transform target)
    {
        if(_targetTransform == null)
            _targetTransform = target;
    }

    private void Update()
    {
        if (_targetTransform == null) return;

        Vector3 direction = (_targetTransform.position - transform.position).normalized;
        _movement = new Vector2(direction.x, direction.y) * _moveSpeed;;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _movement;
    }
}