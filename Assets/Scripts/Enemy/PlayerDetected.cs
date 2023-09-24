using System;
using UnityEngine;

public class PlayerDetected : EnemyDetected
{
    public override event Action<Transform> OnDetectedObject;

    public override void DetectedLogick()
    {
        Collider2D[] detectedEnemies = Physics2D.OverlapCircleAll(transform.position, _detectionRange, _detectedlayerMask);

        if (detectedEnemies.Length > 0)
            foreach (Collider2D enemyCollider in detectedEnemies)
            {
                OnDetectedObject?.Invoke(enemyCollider.transform);
                this.enabled = false;
                break;
            }
    }

}