
public class InfiniteGun : GunWeapon
{
    public override void ReloadGun()
    {
        if (!IsReadyReload || _currentAmmo == _statsGun.MaxAmmo) return;

        StartTimer(_reloadTimer);

        _currentAmmo = _statsGun.MaxAmmo;
    } 
}