using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHitArea : MonoBehaviour
{
    [HideInInspector]
    public EnemyData data;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Core.Instance.gameManager.playerHealth.SetHealth(data.damage);
        }
    }
}
