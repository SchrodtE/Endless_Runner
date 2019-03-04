using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public GameObject prefabWall;
    public GameObject prefabEnemy;
    public GameObject prefabHuman;


    // Start is called before the first frame update
    void Start()
    {

        var ran = Random.Range(0, 6);

        if (ran == 0) SpawnEnemyAt("Spawn1");
        if (ran == 1) SpawnHumanAt("Spawn2");
        if (ran == 2) SpawnEnemyAt("Spawn3");
        if (ran == 3) SpawnHumanAt("Spawn4");
        if (ran == 4) SpawnEnemyAt("Spawn5");
        if (ran == 5) SpawnHumanAt("Spawn1");
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

    private void SpawnHumanAt(string name)
    {
        if(Random.Range(0, 100) < 50)
        {
            Vector3 position = transform.Find(name).position;
            GameObject obj = Instantiate(prefabHuman, position, Quaternion.identity);
            SceneController.humans.Add(obj);
        }
    }
}
