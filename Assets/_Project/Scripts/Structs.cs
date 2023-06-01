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


