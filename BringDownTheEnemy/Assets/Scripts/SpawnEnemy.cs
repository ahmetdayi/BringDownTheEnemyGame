using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPb;
    private float spawnBound = 9;
    void Start()
    {
        var randomPos = GenerateRandomPos();
        Instantiate(enemyPb, randomPos, enemyPb.transform.rotation);
    }

    private Vector3 GenerateRandomPos()
    {
        float randomSpawnX = Random.Range(-spawnBound, spawnBound);
        float randomSpawnZ = Random.Range(-spawnBound, spawnBound);
        Vector3 randomPos = new Vector3(randomSpawnX, 0, randomSpawnZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
