using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    //Change this to spawn waves at certain intervals, limit number of enemies in the game at a time, spawn from multiple points

    [HideInInspector] public static int numEnemies;

    public Transform enemyPrefab;
    private Transform spawnPoint;
    public Transform[] spawnPoints;

    public float timeBetweenWaves = 60f;
    private float countdown = 2f; //counts down to start of wave

    public TMP_Text waveCountdownText;
    private int waveNum = 0;

    void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    /*IEnumerator SpawnWave()
    {
        //numEnemies = waveNumber * waveNum + 1;
        for(int i = 0; i < waveNum; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveNum++;
    }*/

    IEnumerator SpawnWave()
    {
        
        if(numEnemies < 25)
        {
            for (int i = 0; i < waveNum; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
            waveNum++;
        }
    }

    void SpawnEnemy()
    {
        spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        numEnemies++;
    }
}
