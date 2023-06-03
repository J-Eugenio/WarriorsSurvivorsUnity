using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GamePlayHudManager : MonoBehaviour
{

    public Image XpFillAmount;
    public TMP_Text gamePlayTime;
    public GameObject upgradeWindow;

    public void UpdateXpBar(float fillAmount) {
        XpFillAmount.fillAmount = fillAmount;
    }

    public void UpdateGamePlayTime(int minutes, int seconds) {
        gamePlayTime.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
    }

    public void ShowUpgradeWindow() {
        upgradeWindow.SetActive(true);
    }
}
