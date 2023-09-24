using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControllerGun : MonoBehaviour
{
    [SerializeField] private Gun _currentWeapon;
    [SerializeField] private GunAim _currentAim;
    [SerializeField] private Button _fireButton;
    [SerializeField] private Button _relaodButton;
    [SerializeField] private TMP_Text _ammoText;


    public void SetupGun(Gun gun)
    {
        if (gun == _currentWeapon || !_currentWeapon.IsReaduReload) return;

        _currentWeapon.gameObject.SetActive(false);
        _currentWeapon = gun;
        _currentWeapon.gameObject.SetActive(true);
        _currentAim.UpdateRange(_currentWeapon.StatsGun.FiringRange);
    }

    public void FireGun()
    {
        _currentWeapon.FireGun();
        _fireButton.interactable = false;
    }

    public void ReloadGun()
    {
        _currentWeapon.ReloadGun();
        _relaodButton.interactable = false;
    }

    private void LateUpdate()
    {
        if(_currentWeapon.IsReaduReload)
            _ammoText.text = $"{_currentWeapon.CurrentAmmo}/{_currentWeapon.StatsGun.MaxAmmo}";

        if (_currentWeapon.IsReaduReload)
            _relaodButton.interactable = true;
        if(_currentWeapon.IsReadyFire)
            _fireButton.interactable = true;
    }
}