using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public GameObject prefabWall;
    public GameObject prefabEnemy;


    // Start is called before the first frame update
    void Start()
    {

        SpawnWallAt("Spawn1");
        SpawnWallAt("Spawn2");
        SpawnWallAt("Spawn3");

        float spawnLoc = Random.Range(1, 9);

        if (spawnLoc <= 3)
        {
            SpawnEnemyAt("Spawn1");
            print("1");
        }

        if (spawnLoc <= 6 && spawnLoc >= 4)
        {
            SpawnEnemyAt("Spawn2");
            print("2");
        }
        if(spawnLoc >= 7)
        {
            SpawnEnemyAt("Spawn3");
            print("3");
        }
    }

    private void SpawnWallAt(string name)
    {
        if(Random.Range(0, 100) < 50)
        {
            Vector3 position = transform.Find(name).position;
            GameObject obj = Instantiate(prefabWall, position, Quaternion.identity);
            SceneController.walls.Add(obj);
        }
    }

    private void SpawnEnemyAt(string name)
    {
        if(Random.Range(0, 100) > 50)
        {
            Vector3 position = transform.Find(name).position;
            GameObject obj = Instantiate(prefabEnemy, position, Quaternion.identity);
            SceneController.enemies.Add(obj);
        }
    }
}
