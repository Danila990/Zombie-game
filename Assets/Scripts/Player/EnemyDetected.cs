using System;
using UnityEngine;

public class EnemyDetected : DetectedObject
{
    public override event Action<Transform> OnDetectedObject;

    public override void DetectedLogick()
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
}
