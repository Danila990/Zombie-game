using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControllerWeapon : MonoBehaviour
{
    [SerializeField] private GunWeapon _currentGun;
    [SerializeField] private WeaponAim _currentAim;
    [SerializeField] private Button _fireButton;
    [SerializeField] private Button _relaodButton;
    [SerializeField] private TMP_Text _ammoText;


    public void SetupGun(GunWeapon gunWeapon)
    {
        if (gunWeapon == _currentGun || !_currentGun.IsReadyReload) return;

        _currentGun.gameObject.SetActive(false);
        _currentGun = gunWeapon;
        _currentGun.gameObject.SetActive(true);
        _currentAim.UpdateRange(_currentGun.StatsGun.AttackRange);
    }

    public void FireGun()
    {
        _currentGun.AttackGun();
        _fireButton.interactable = false;
    }

    public void ReloadGun()
    {
        _currentGun.ReloadGun();
        _relaodButton.interactable = false;
    }

    private void LateUpdate()
    {
        if(_currentGun.IsReadyReload)
            _ammoText.text = $"{_currentGun.CurrentAmmo}/{_currentGun.StatsGun.MaxAmmo}";

        if (_currentGun.IsReadyReload)
            _relaodButton.interactable = true;
        if(_currentGun.IsReadyAttack)
            _fireButton.interactable = true;
    }
}