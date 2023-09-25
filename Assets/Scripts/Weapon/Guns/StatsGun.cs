using UnityEngine;

[System.Serializable]
public class StatsGun
{
    public float AttackSpeed => _attackSpeed;
    public float AttackRange => _attackRange;
    public int MaxAmmo => _maxAmmo;
    public float ReloadRate => _reloadSpeed;
    public float BulletSpeed => _bulletSpeed;
    public float Damage => _damage;

    [SerializeField] private float _damage = 20;
    [SerializeField] private float _attackSpeed = 0.3f;
    [SerializeField] private float _reloadSpeed = 3;
    [SerializeField] private float _attackRange = 10f;
    [SerializeField] private float _bulletSpeed = 5f;
    [SerializeField] private int _maxAmmo = 15;
}