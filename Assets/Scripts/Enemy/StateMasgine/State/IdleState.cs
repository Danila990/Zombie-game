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
    private float _timerMove = 0;
    private Vector3 _randomPoint = Vector3.zero;

    private void OnEnable()
    {
        _enemyHealth.OnTakeDamage += Exit;
        RandomPoint();
    }

    private void OnDisable()
    {
        _enemyHealth.OnTakeDamage -= Exit;
    }

    private void Update()
    {
        _timerMove += Time.deltaTime;
        if (_timerMove >= _timeToMove && _isAwaitMove)
        {
            _isAwaitMove = false;
            RandomPoint();
            _timerMove = _timeToMove;
        }
    }

    private void LateUpdate()
    {
        if (Vector3.Distance(_randomPoint, transform.position) <= 0.3f && !_isAwaitMove)
            _isAwaitMove = true;

        if (Vector3.Distance(_player.transform.position, transform.position) <= _triggerRange && _player.gameObject.activeSelf)
            Exit();

        Vector3 direction = _randomPoint - transform.position;
        transform.Translate(direction.normalized * _speedIdle * Time.deltaTime);
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