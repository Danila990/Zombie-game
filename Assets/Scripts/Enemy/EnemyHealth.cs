using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, ITakeDamage
{
    public event Action OnTakeDamage;

    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private DropItem _dropItem;
    [SerializeField] private EnemyStateMashine _stateMashine;

    private float _currentHealth;
    
    private void Awake()
    {
        _currentHealth = _maxHealth;
        _healthBar.SetupBar(_currentHealth, _maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth - damage <= 0)
            EnemyDead();

        OnTakeDamage?.Invoke();
        _currentHealth -= damage;
        _healthBar.UpdateBar(_currentHealth);
    }

    public void EnemyDead()
    {
        Instantiate(_dropItem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}