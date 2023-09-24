using System;
using UnityEngine;

public class EnemyDetected : MonoBehaviour
{
    public event Action<Transform> OnDetectedObject;

    [SerializeField] protected float _detectionRange = 5f;
    [SerializeField] protected LayerMask _detectedlayerMask;
    [SerializeField] private Color _gizmosColor = Color.red;

    public void SetupDetectionRange(float range)
    {
        _detectionRange = range;
    }

    private void LateUpdate()
    {
        Collider2D[] detectedEnemies = Physics2D.OverlapCircleAll(transform.position, _detectionRange, _detectedlayerMask);

        if (detectedEnemies.Length > 0)
        {
            Transform closestObject = null;
            float closestDistance = float.MaxValue;

            foreach (Collider2D collider in detectedEnemies)
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObject = collider.transform;
                }
            }
            OnDetectedObject.Invoke(closestObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(transform.position, _detectionRange);
    }
}
