using UnityEngine;

public class StandartGun : Gun
{
    [SerializeField] private string _needAmmoId;
    [SerializeField] private BackpackInventory _inventory;

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
        if(_inventory.Finditem(_needAmmoId, out int countItem))
        {
            ReloadTimer();

            if (countItem > _statsGun.MaxAmmo - _currentAmmo)
            {
                _inventory.RemoveCountItem(_needAmmoId, _statsGun.MaxAmmo - _currentAmmo);
                _currentAmmo = _statsGun.MaxAmmo;
            }
            else
            {
                _currentAmmo += countItem;
                _inventory.RemoveCountItem(_needAmmoId, countItem);
            }
        }
    }
}