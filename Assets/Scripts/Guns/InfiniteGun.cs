
public class InfiniteGun : Gun
{
    public override void FireGun()
    {
        if (!_isReaduFire || _currentAmmo <= 0 || !_isReaduReload) return;

        _currentAmmo--;

        SpawnBullet();
        FireTimer();
    }

    public override void ReloadGun()
    {
        if (!_isReaduReload || _currentAmmo == _statsGun.MaxAmmo) return;

        ReloadTimer();

        _currentAmmo = _statsGun.MaxAmmo;
    }
}