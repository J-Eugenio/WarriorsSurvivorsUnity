using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public PowerUpData powerUpTemp;
    public int level;

    public Dictionary<PowerUpData, int> passiveBonus = new Dictionary<PowerUpData, int>();

    private void Start() {
        passiveBonus.Add(powerUpTemp, level);
    }

    public float GetPowerUpBonus(PowerUpData powerUp) {
        float bonus = 0f;

        //Pegar o bonus da loja
        if(powerUp.powerUpLevel > 0) {
            bonus = powerUp.powerUpLevel * powerUp.bonus.value;
        }

        //Pegar o bonus de upgrades da gameplay
        if(passiveBonus.ContainsKey(powerUp)) {
            bonus += powerUp.passive.value * passiveBonus[powerUp];
        }

        //Pegar o bonus inerente aos herois
        if(Core.Instance.gameManager.selectedHero.GetHeroPowerUpBonus(powerUp) > 0) {
            bonus += Core.Instance.gameManager.selectedHero.GetHeroPowerUpBonus(powerUp);
        }
        return bonus;
    }
}
