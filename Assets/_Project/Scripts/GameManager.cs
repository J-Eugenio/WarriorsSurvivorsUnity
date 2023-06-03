using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HeroData selectedHero;
    [HideInInspector]
    public Transform player;
    [HideInInspector]
    public PlayerHealth playerHealth;

    public int playerLevel = 0;
    public float XP;
    public int[] XpLevel;
    public float Coins;
    private GameState gameState;

    public void PlayerRegister(Transform player) {
        this.player = player;
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
    }

    public GameState GetGameState() {
        return gameState;
    }

    public void ChangeGameState(GameState gameState) {
        this.gameState = gameState;

        switch (gameState) {
            case GameState.GAMEPLAY:
                Time.timeScale = 1;
                break;
            case GameState.UPGRADE:
                Time.timeScale = 0;
                Core.Instance.gpHubManager.ShowUpgradeWindow();
                break;

        }
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
        if(XP >= XpLevel[playerLevel]) {
            playerLevel += 1;
            XP = 0;
            ChangeGameState(GameState.UPGRADE);
        }

        float percXp = XP / (float)XpLevel[playerLevel];
        Core.Instance.gpHubManager.UpdateXpBar(percXp);

    }

    public bool CheckLuck(int value) {
        return value <= Random.Range(0, 100);
    }
}
