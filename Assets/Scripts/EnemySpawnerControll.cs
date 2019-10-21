using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerControll : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;
    int randomSpawnPoint;
    public static bool spawnAllowed;
 

    //spawn val
    public static float waveSpeed = 4f;
    private float wave = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
    }

    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if(spawnAllowed)
        {
            if (Time.time > wave)
            {
                wave = Time.time + waveSpeed;
                randomSpawnPoint = Random.Range(0, spawnPoints.Length);
                Instantiate(enemy, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
            }
        }
    }
}
