using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAreaEffect : MonoBehaviour
{
    public WeaponData data;
    public float lifeTime;
    public bool isTemporary;

    private void Start() {
        if (isTemporary) {
            Invoke(nameof(Disable), lifeTime);    
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if(damageable != null) {
            damageable.TakeDamage(data.damage, data.knockBack);
        }
    }

    private void Disable() {
        Destroy(this);
    }
}
