using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEffect : MonoBehaviour
{

    public WeaponData data;
    public int hitAmount;

    private void OnTriggerEnter2D(Collider2D collision) {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null) {
            damageable.TakeDamage(data.damage, data.knockBack);
            hitAmount -= 1;

            if(hitAmount <= 0) {
                Destroy(this.gameObject);
            }
        }
    }
}
