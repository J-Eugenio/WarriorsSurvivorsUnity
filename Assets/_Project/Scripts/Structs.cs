using System;
using UnityEngine;

[Serializable]
public struct PowerUpBonus {
    [Range(1, 10)]
    public int maxLevel;
    public float value;
    [TextArea(3,3)]
    public string description;
}

[Serializable]
public struct HeroPowerUpBonus {
    public PowerUpData powerUp;
    public float value;
}

[Serializable]
public struct EnemiesAmount {
    public EnemyData enemy;
    public int amount;
}

[Serializable]
public struct WaveController {
    public EnemiesAmount[] enemies;
    public float intervalBetweenEnemies;
}
