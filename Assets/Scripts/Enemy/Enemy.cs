using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent (typeof(EnemyMovement), typeof(PlayerDetected))]
public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _currentHealth;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private DropItem _dropItem;

    private PlayerDetected _playerDetected;
    private Transform _targetPlayer;

    private void Start()
    {
        _playerDetected = GetComponent<PlayerDetected>();
        _playerDetected.OnDetectedObject += MoveTarget;
        _healthBar.SetupBar(_currentHealth, _maxHealth);
    }

    private void OnDestroy()
    {
        _playerDetected.OnDetectedObject -= MoveTarget;
    }

    public void Init(Transform target)
    {
        _targetPlayer = target;
    }

    private void MoveTarget(Transform target)
    {
        _targetPlayer = target;
        _enemyMovement.SetupTarget(_targetPlayer);
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth - damage <= 0)
            EnemyDead();

        _enemyMovement.SetupTarget(_targetPlayer);
        _currentHealth -= damage;
        _healthBar.UpdateBar(_currentHealth);
    }

    private void EnemyDead()
    {
        Instantiate(_dropItem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}