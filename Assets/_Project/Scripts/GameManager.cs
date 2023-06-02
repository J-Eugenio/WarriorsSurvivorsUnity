using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HeroData selectedHero;
    [HideInInspector]
    public Transform player;
    [HideInInspector]
    public PlayerHealth playerHealth;

    public float XP;
    public float Coins;

    public void PlayerRegister(Transform player) {
        this.player = player;
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
    }

    public void GetItemCollectible(ItemCollectible item) {
        switch(item.itemType) {
            case CollectibleType.XP:
                GetXP(item.value);
                break;

            case CollectibleType.Coin:
                Coins += item.value;
                break;

            case CollectibleType.Recovery:
                playerHealth.SetHealth(item.value, true);
                break;
        }
    }

    private void GetXP(float amount) {
        XP += amount;
    }
}
