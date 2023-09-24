using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _currentHealth;
    [SerializeField] private HealthBar _healthBar;

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

    private void Dead()
    {
        gameObject.SetActive(false);
    }
}
