using UnityEngine;

public class BulletPull : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _barrelGun;

    private Bullet[] _bulletArray;

    public void CreatePull(int maxBullet)
    {
        _bulletArray = new Bullet[maxBullet];
        for (int i = 0; i < _bulletArray.Length; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab);
            bullet.Init();
            bullet.gameObject.SetActive(false);

            _bulletArray[i] = bullet;
        }
    }

    public void SpawnBullet(float speed, float damage) 
    {
        Bullet bullet = GetBullet();
        bullet.gameObject.SetActive(true);
        bullet.transform.SetPositionAndRotation(_barrelGun.position, _barrelGun.rotation);
        bullet.SetupBullet(speed, damage, _barrelGun.right);
    }

    private Bullet GetBullet()
    {
        foreach (Bullet bullet in _bulletArray)
            if (bullet.gameObject.activeSelf == false)
                return bullet;

        return null;
    }
}