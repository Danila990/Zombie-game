using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _layerNumber = 6;
    [SerializeField] private float _lifeTimer = 5;

    private float _damage = 10;
    private float _speed = 10;
    private Rigidbody2D _rigidbody;
    private Vector3 _duraction;
    private float _timeToDead;

    public void Init()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetupBullet(float speed, float damage,  Vector3 duraction)
    {
        _timeToDead = _lifeTimer;
        _speed = speed;
        _duraction = duraction;
        _damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == _layerNumber)
        {
            collision.GetComponent<ITakeDamage>().TakeDamage(_damage);
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(_timeToDead > 0)
        {
            _timeToDead -= Time.deltaTime;
            if(_timeToDead <= 0)
                gameObject.SetActive(false);
        } 
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _duraction * _speed;
    }
}