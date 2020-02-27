using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnrange = 9.0f;
    public int EnemyCount;
    public int wave = 1;
    public GameObject powerup;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerup, GenerateSpawnPos(), powerup.transform.rotation);
        spawnEnemyWave(wave);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCount = FindObjectsOfType<Enemy>().Length;
        if(EnemyCount == 0)
        {
            wave++;
            spawnEnemyWave(wave);
            Instantiate(powerup, GenerateSpawnPos(), powerup.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnposX = Random.Range(spawnrange, -spawnrange);
        float spawnposZ = Random.Range(spawnrange, -spawnrange);
        Vector3 randompos = new Vector3(spawnposX, 0, spawnposZ);
        
        return randompos;
    }

    void spawnEnemyWave(int EnemysToSpawn)
    {
        for (int i = 0; i < EnemysToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
}
