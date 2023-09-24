using System.Threading.Tasks;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public bool IsReadyFire => _isReaduFire;
    public bool IsReaduReload => _isReaduReload;
    public StatsGun StatsGun => _statsGun;
    public int CurrentAmmo => _currentAmmo;

    [SerializeField] protected StatsGun _statsGun;
    [SerializeField] protected int _currentAmmo;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _barrelGun;

    protected bool _isReaduFire = true;
    protected bool _isReaduReload = true;
    private Bullet[] _bulletArray;

    private void Awake()
    {
        CreateBulletPull();
    }

    public abstract void FireGun();
    public abstract void ReloadGun();

    protected void SpawnBullet()
    {
        foreach (Bullet bullet in _bulletArray)
            if (bullet.gameObject.activeSelf == false)
            {
                bullet.gameObject.SetActive(true);
                bullet.transform.SetPositionAndRotation(_barrelGun.position, _barrelGun.rotation);
                bullet.SetupBullet(_statsGun.BulletSpeed, _statsGun.Damage, _barrelGun.right);
                return;
            }
    }

    protected async void ReloadTimer()
    {
        _isReaduReload = false;
        await Task.Delay((int)(_statsGun.ReloadRate * 1000));
        _isReaduReload = true;
    }

    protected async void FireTimer()
    {
        _isReaduFire = false;
        await Task.Delay((int)(_statsGun.FireRate * 1000));
        _isReaduFire = true;
    }

    private void CreateBulletPull()
    {
        _bulletArray = new Bullet[_statsGun.MaxAmmo];
        for (int i = 0; i < _bulletArray.Length; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab);
            bullet.Init();
            bullet.gameObject.SetActive(false);

            _bulletArray[i] = bullet;
        }
    }
}