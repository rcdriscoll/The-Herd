using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemyPrefabs;
    private Vector3 spawnObstaclePos;

    void Update()
    {
        float distanceToHorizon = Vector3.Distance(player.gameObject.transform.position, spawnObstaclePos);

        if (distanceToHorizon < 120)
        {
            SpawnTriangles();
        }
    }

    void SpawnTriangles()
    {
        spawnObstaclePos = new Vector3(0, 0, spawnObstaclePos.z + 30); //30 is distance between Enemies

        //this is where we actually spawn the Enemy
        Instantiate(enemyPrefabs[(Random.Range(0, enemyPrefabs.Length))], spawnObstaclePos, Quaternion.identity); // quaternion just has it as defalut rotation
    }
}
