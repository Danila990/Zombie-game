using UnityEngine;

public class StandartGun : GunWeapon
{
    [SerializeField] private string _needAmmoId;
    [SerializeField] private BackpackInventory _inventory;

    public override void ReloadGun()
    {
        if (!IsReadyReload || _currentAmmo == _statsGun.MaxAmmo) return;
        if (_inventory.Finditem(_needAmmoId, out int countItem))
        {
            StartTimer(_reloadTimer);

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