using UnityEngine;

[RequireComponent(typeof(EnemyDetected))]
public class GunAim : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _aimRange = 5f;


    private EnemyDetected _enemyDetected;
    private Transform _targetTransform;
    private Vector3 _duraction;

    private void Start()
    {
        _enemyDetected = GetComponent<EnemyDetected>();
        _enemyDetected.SetupDetectionRange(_aimRange);
        _enemyDetected.OnDetectedObject += SetupTarget;
    }

    private void OnDestroy()
    {
        _enemyDetected.OnDetectedObject -= SetupTarget;
    }

    public void UpdateRange(float range)
    {
        _aimRange = range;
        _enemyDetected.SetupDetectionRange(_aimRange);
    }

    private void SetupTarget(Transform target) => _targetTransform = target;

    private void LateUpdate()
    {
        if (_targetTransform != null && _targetTransform.gameObject.activeSelf)
        {
            if(Vector3.Distance(transform.position, _targetTransform.position) > _aimRange)
            {
                _targetTransform = null;
                return;
            }

            Vector2 directionToEnemy = _targetTransform.position - transform.position;
            CalculateDuraction(directionToEnemy.y, directionToEnemy.x);
            return;
        }

        CalculateDuraction(_joystick.Vertical, _joystick.Horizontal);
    }

    private void CalculateDuraction(float y, float x)
    {
        if(y >= 0.5f || y <= -0.5f || x >= 0.5f || x <= -0.5f)
            _duraction = new Vector3(x, y, 0f);

        float angle = Mathf.Atan2(_duraction.y, _duraction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}