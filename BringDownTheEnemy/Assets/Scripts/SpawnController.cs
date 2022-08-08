using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnController : MonoBehaviour
{
    public GameObject enemyPb;
    private float spawnBound = 9;
    public GameObject powerUpPrefab;
    private int waveNumber = 1;
    private int enemyCount=0;
    private PlayerController _playerController;
    public Text waveText;
    void Start()
    {
        _playerController = GameObject.Find("Player").gameObject.GetComponent<PlayerController>();
        SpawnEnemyWave(1);
        Instantiate(powerUpPrefab, GenerateRandomPos(), powerUpPrefab.transform.rotation);
        
        
        
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
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        waveText.text = "Wave : "+waveNumber.ToString();
        
        if (enemyCount == 0 && _playerController.isGameOver == false )
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefab, GenerateRandomPos(), powerUpPrefab.transform.rotation);


        }
    }

    private void SpawnEnemyWave(int waveValue)
    {
        for (int i = 0; i < waveNumber; i++)
        {
            Instantiate(enemyPb, GenerateRandomPos(), enemyPb.transform.rotation);
        }
        
        
    }
}
