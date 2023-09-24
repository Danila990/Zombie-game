using System.Threading.Tasks;
using UnityEngine;

public class IdleState : EnemyState
{
    [SerializeField] private float _triggerRange = 5;
    [SerializeField] private float _timeToMove = 2;
    [SerializeField] private float _speedIdle = 5;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private float _rangeMove = 4;

    private bool _isAwaitMove = true;
    private Vector3 _randomPoint;

    private void OnEnable()
    {
        _enemyHealth.OnTakeDamage += Exit;
        RandomPoint();
    }

    private void OnDisable()
    {
        _enemyHealth.OnTakeDamage -= Exit;
    }

    private void LateUpdate()
    {
        if(_randomPoint == transform.position && _isAwaitMove)
            AwaitTime();

        if (Vector3.Distance(_player.transform.position, transform.position) <= _triggerRange)
            Exit();

        Vector3 direction = _randomPoint - transform.position;
        transform.Translate(direction.normalized * _speedIdle * Time.deltaTime);
    }

    private async void AwaitTime()
    {
        _isAwaitMove = false;
        await Task.Delay((int) _timeToMove * 1000);
        RandomPoint();
        _isAwaitMove = true;
    }

    private void RandomPoint()
    {
        _randomPoint = new Vector3(transform.position.x + Random.Range(-_rangeMove, _rangeMove), transform.position.y + Random.Range(-_rangeMove, _rangeMove), 0);
    }

    public override void Exit()
    {
        _stateMashine.TransitToNext();
    }
}