using System.Threading.Tasks;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _layerNumber = 7;
    [SerializeField] private float _attackRate = 0.5f;
    [SerializeField] private float _damage = 20;

    private bool _isReadiAttack = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _layerNumber && _isReadiAttack)
        {
            FireTimer();
            collision.GetComponent<ITakeDamage>().TakeDamage(_damage);
        }
    }

    private async void FireTimer()
    {
        _isReadiAttack = false;
        await Task.Delay((int)(_attackRate * 1000));
        _isReadiAttack = true;
    }
}