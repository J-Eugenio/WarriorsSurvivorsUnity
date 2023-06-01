using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = Core.Instance.gameManager.selectedHero.maxHealth;
    }

    public void SetHealth(float value, bool recovery = false) {
        if(!recovery) {
            currentHealth -= value;
            if(currentHealth < 0) {
                print("Voce Morreu");
            }
        } else {
            currentHealth += value;
            if(currentHealth > Core.Instance.gameManager.selectedHero.maxHealth) {
                currentHealth = Core.Instance.gameManager.selectedHero.maxHealth;
            }
        }
    }
}
