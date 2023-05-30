using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptable/Enemy", order =3)]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public Sprite enemyPortrait;

    public GameObject prefab;

    public float targetUpdateDelay;
    public float moveSpeed;
    public float maxHealth;
    public float damage;
    public int xp;
}
