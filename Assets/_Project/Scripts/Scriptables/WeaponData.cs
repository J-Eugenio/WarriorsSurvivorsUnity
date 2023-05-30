using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Scriptable/Weapon", order = 1)]
public class WeaponData : ScriptableObject
{
    public GameObject prefab;
    public float damage;
    public float knockBack;
}
