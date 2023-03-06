using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject powerUp;

    public PlayerController playerScript;

    float zRange = 8;
    float xRange = 9;

    float spawnInterval = 2f;
    float startSpawn = 2f;

    float powerSpawn = 7f;
    void Start()
    {
        playerScript = GetComponent<PlayerController>();


        InvokeRepeating("SpawnEnemies", startSpawn, spawnInterval);

        if (playerScript.isPower == false)
        {
            InvokeRepeating("SpawnPowerUps", spawnInterval, spawnInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        float randomZRange = Random.Range(-zRange, zRange);
        float randomXRange = Random.Range(-xRange, xRange);

        Vector3 spawnRange = new Vector3(randomXRange, 0.7f, randomZRange);

        Instantiate(enemy, spawnRange, enemy.transform.rotation);
    }
    void SpawnPowerUps()
    {
        float randomZRange = Random.Range(-zRange, zRange);
        float randomXRange = Random.Range(-xRange, xRange);

        Vector3 spawnRange = new Vector3(randomXRange, 6f, randomZRange);
        Instantiate(powerUp, spawnRange, powerUp.transform.rotation);
    }

    IEnumerator WaitForPower(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
