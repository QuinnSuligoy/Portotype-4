using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnrange = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnposX = Random.Range(spawnrange, -spawnrange);
        float spawnposZ = Random.Range(spawnrange, -spawnrange);
        Vector3 randompos = new Vector3(spawnposX, 0, spawnposZ);
        
        return randompos;
    }
}
