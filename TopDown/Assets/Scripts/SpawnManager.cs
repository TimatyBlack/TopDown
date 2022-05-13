using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public PlayerMovement player;
    public Enemy enemyPrefab;
    public int spawnRange = 14;
    public int waveNumber = 1;
    public int enemyCount;
    Vector2 spawnPos;

     //Start is called before the first frame update        
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
   
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    private Vector3 GenSpawnPos()
    {
        int z = Random.Range(-spawnRange, spawnRange);
        int y = Random.Range(-spawnRange, spawnRange);
        spawnPos = new Vector2(z, y);

        return spawnPos;
    }
    

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++){
            Enemy enemy = Instantiate(enemyPrefab, GenSpawnPos(), Quaternion.identity);
            enemy.SetPlayer(player.transform);
        }
    }
}

