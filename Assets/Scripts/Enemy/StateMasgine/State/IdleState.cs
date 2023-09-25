using UnityEngine;

public class IdleState : EnemyState
{
    private bool _isAwaitMove => _timer.IsTimerEnd;

    [SerializeField] private float _triggerRange = 5f;
    [SerializeField] private float _awaitTime = 2f;
    [SerializeField] private float _speedIdle = 5f;
    [SerializeField] private float _rangeMove = 4f;
    [SerializeField] private EnemyHealth _enemyHealth;

    private Vector3 _randomPoint = Vector3.zero;
    private Timer _timer;

    private void OnEnable()
    {
        _enemyHealth.OnTakeDamage += Exit;
        _timer = new Timer(_awaitTime);
        RandomPoint();
    }

    private void OnDisable()
    {
        _enemyHealth.OnTakeDamage -= Exit;
    }

    private void LateUpdate()
    {
        if (_isAwaitMove)
        {
            Vector3 direction = _randomPoint - transform.position;
            transform.Translate(direction.normalized * _speedIdle * Time.deltaTime);

            if (Vector3.Distance(_randomPoint, transform.position) <= 0.3f)
            {
                _timer.StartTime();
                RandomPoint();
            }    
        }


        if (Vector3.Distance(_player.transform.position, transform.position) <= _triggerRange && _player.gameObject.activeSelf)
            Exit();
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