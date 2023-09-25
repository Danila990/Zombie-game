using UnityEngine;

[RequireComponent(typeof(BulletPull))]
public abstract class GunWeapon : MonoBehaviour
{
    public bool IsReadyAttack => _attackTimer.IsTimerEnd;
    public bool IsReadyReload => _reloadTimer.IsTimerEnd;
    public float CurrentAmmo => _currentAmmo;
    public StatsGun StatsGun => _statsGun;

    [SerializeField] protected StatsGun _statsGun;

    protected int _currentAmmo = 0;
    protected BulletPull _bulletPull;
    protected Timer _attackTimer;
    protected Timer _reloadTimer;

    public abstract void ReloadGun();

    public void Awake()
    {
        _currentAmmo = _statsGun.MaxAmmo;
        _bulletPull = GetComponent<BulletPull>();
        _bulletPull.CreatePull(_statsGun.MaxAmmo);

        _attackTimer = new Timer(_statsGun.AttackSpeed);
        _reloadTimer = new Timer(_statsGun.ReloadRate);
    }

    public void AttackGun()
    {
        if (!IsReadyAttack || _currentAmmo <= 0 || !IsReadyReload) return;

        _currentAmmo--;

        _bulletPull.SpawnBullet(_statsGun.BulletSpeed, _statsGun.Damage);
        StartTimer(_attackTimer);
    }

    protected void StartTimer(Timer timer)
    {
        timer.StartTime();
    }
}