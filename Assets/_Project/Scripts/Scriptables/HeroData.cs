using UnityEngine;

[CreateAssetMenu(fileName = "New Hero", menuName = "Scriptable/hero", order = 0)]
public class HeroData : ScriptableObject
{
    public GameObject prefab;
    public float moveSpeed;

    public WeaponData startingWeapon;
}
