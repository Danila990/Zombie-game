using UnityEngine;

[System.Serializable]
public class StatsGun
{
    public float FireRate => _fireRate;
    public float FiringRange => _firingRange;
    public int MaxAmmo => _maxAmmo;
    public float ReloadRate => _reloadRate;
    public float BulletSpeed => _bulletSpeed;
    public float Damage => _damage;

    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _firingRange = 5f;
    [SerializeField] private int _maxAmmo = 10;
    [SerializeField] private float _reloadRate = 5f;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _damage = 10;
}