using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable/Item", order = 5)]

public class ItemData : ScriptableObject
{
    public ItemType itemType;
    public PowerUpData powerUpData;
    public WeaponData weaponData;

    public Sprite itemIcon;
}
