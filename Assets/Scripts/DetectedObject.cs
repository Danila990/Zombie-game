using System;
using UnityEngine;

public abstract class DetectedObject : MonoBehaviour
{
    public abstract event Action<Transform> OnDetectedObject;

    [SerializeField] protected float _detectionRange = 5f;
    [SerializeField] protected LayerMask _detectedlayerMask;
    [SerializeField] private Color _gizmosColor = Color.red;

    public void SetupDetectionRange(float range)
    {
        _detectionRange = range;
    }

    public abstract void DetectedLogick();

    private void LateUpdate()
    {
        DetectedLogick();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(transform.position, _detectionRange);
    }
}