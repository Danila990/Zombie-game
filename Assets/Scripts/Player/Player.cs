using System;
using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage
{
    public event Action OnPlayerDead;

    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _currentHealth;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Transform _spawnPoint;

    private void Awake()
    {
        _healthBar.SetupBar(_currentHealth, _maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth - damage <= 0)
            Dead();

        _currentHealth -= damage;
        _healthBar.UpdateBar(_currentHealth);
    }

    public void RespawnPlayer()
    {
        gameObject.SetActive(true);
        _currentHealth = _maxHealth;
        transform.position = _spawnPoint.position;
        _healthBar.UpdateBar(_currentHealth);
    }

    private void Dead()
    {
        OnPlayerDead?.Invoke();
        gameObject.SetActive(false);
    }
}
