using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAreaEffect : MonoBehaviour
{
    public WeaponData data;
    public PowerUpData might;

    public float lifeTime;
    public bool isTemporary;

    private float damage;

    private void Start() {
        if (isTemporary) {
            Invoke(nameof(Disable), lifeTime);    
        }

        CalculateDamage();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if(damageable != null) {
            damageable.TakeDamage(CalculateDamage(), data.knockBack);
        }
    }

    private void Disable() {
        Destroy(this);
    }

    private float CalculateDamage() {
        float bonus = Core.Instance.upgradeManager.GetPowerUpBonus(might);
        switch(might.bonusType) {
            case Unit.Sum:
                damage = data.damage + bonus;
                break;
            case Unit.Percentage:
                damage = data.damage + data.damage * (bonus / 100);
                break;
        }

        print(damage);
        return damage;
    }
}
