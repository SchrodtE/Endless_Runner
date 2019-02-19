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
        //SpawnWallAt("Spawn1");
        //SpawnWallAt("Spawn2");
        //SpawnWallAt("Spawn3");


        SpawnEnemyAt("Spawn1");
        SpawnEnemyAt("Spawn2");
        SpawnEnemyAt("Spawn3");
        SpawnEnemyAt("Spawn4");
        SpawnEnemyAt("Spawn5");

    }

    /**private void SpawnWallAt(string name)
    {
        if(Random.Range(0, 100) < 50)
        {
            Vector3 position = transform.Find(name).position;
            GameObject obj = Instantiate(prefabWall, position, Quaternion.identity);
            SceneController.walls.Add(obj);
        }
    }**/

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
