using UnityEngine;

[CreateAssetMenu(fileName = "New Hero", menuName = "Scriptable/hero", order = 0)]
public class HeroData : ScriptableObject
{
    public GameObject prefab;
    public float moveSpeed;
    public float maxHealth;
    public WeaponData startingWeapon;

    public HeroPowerUpBonus[] abilities;

    public float GetHeroPowerUpBonus(PowerUpData powerUp) {
        float bonus = 0;

        foreach(var ability in abilities) {
            if(ability.powerUp == powerUp) {
                bonus = ability.value;
            }
        }
        return bonus;
    }
}
