using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptable/Enemy", order =3)]
public class EnemyData : ScriptableObject
{
    public float targetUpdateDelay;
    public float moveSpeed;
}
