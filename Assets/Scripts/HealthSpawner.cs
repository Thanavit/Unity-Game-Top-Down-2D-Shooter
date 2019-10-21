using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject healthPack;
    int randomSpawnPoint;



    // Start is called before the first frame update
    void Start()
    {
        SpawnHealth();
        InvokeRepeating("SpawnHealth", 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnHealth();
    }

    void SpawnHealth()
    {
        randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(healthPack, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
    }
}
