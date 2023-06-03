using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public int idWave;
    public WaveController[] waves;
    public Transform SpawnPoinPivot;
    public int maxEnemiesInScene = 100;
    private List<EnemyData> enemiesInScene = new List<EnemyData>();

    private int seconds;
    public int minutes;

    private Dictionary<EnemyData, int> enemyTypeAmount = new Dictionary<EnemyData, int>();

    void Start()
    {
        Core.Instance.waveManager = this;
        StartCoroutine(nameof(IESpawn));
        StartCoroutine(nameof(IEGameTime));
    }

    private void LateUpdate() {
        SpawnPoinPivot.position = Core.Instance.gameManager.player.position;
    }

    private  void EnemyRegister(EnemyData data) {
        enemiesInScene.Add(data);

        if(enemyTypeAmount.ContainsKey(data)) {
            enemyTypeAmount[data] += 1;
        }else {
            enemyTypeAmount.Add(data, 1);
        }
    }

    public void EnemyUnregister(EnemyData data) {
        enemiesInScene.Remove(data);
        if (enemyTypeAmount.ContainsKey(data)) {
            enemyTypeAmount[data] -= 1;
            if(enemyTypeAmount[data] <= 0) {
                enemyTypeAmount.Remove(data);
            }
        }
    }

    IEnumerator IESpawn() {
        WaveController wave = waves[idWave];
        yield return new WaitForSeconds(0.3f);

        while (true) {
            yield return new WaitUntil(() => enemiesInScene.Count < maxEnemiesInScene);

            int idMob = Random.Range(0, wave.enemies.Length);
            EnemyData enemyData = wave.enemies[idMob].enemy;

            if (enemyTypeAmount.ContainsKey(enemyData)) {
                if(enemyTypeAmount[enemyData] < wave.enemies[idMob].amount) {
                    NewMob(enemyData);
                }
            }
            else {
                NewMob(enemyData);
            }

            
            yield return new WaitForSeconds(wave.intervalBetweenEnemies);
        }
    }

    IEnumerator IEGameTime() {
        while(true) {
            yield return new WaitForSeconds(1);
            seconds += 1;
            if(seconds == 10) {
                seconds = 0;
                minutes += 1;
                NextWave();
            }

            Core.Instance.gpHubManager.UpdateGamePlayTime(minutes, seconds);
        }
    }
    private void NewMob(EnemyData data) {
        EnemyRegister(data);
        GameObject mob = Instantiate(data.prefab);

        int idSpawnPoint = Random.Range(0, spawnPoints.Length);
        mob.transform.position = spawnPoints[idSpawnPoint].position;
    }

    private void NextWave() {
        idWave += 1;
        if(idWave < waves.Length) {
            StopCoroutine(nameof(IESpawn));
            StartCoroutine(nameof(IESpawn));
        }
        
    }
}
