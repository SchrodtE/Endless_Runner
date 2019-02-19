using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1 : MonoBehaviour
{
    public GameObject prefabCoffee;
    public GameObject prefabBalloon;
    public GameObject prefabBike;
    // Start is called before the first frame update
    void Start()
    {
        //ColliderAABB collider = GetComponent<ColliderAABB>();

        //CollisionManager.walls.Add(collider);

        SpawnItemAt("Spawn1 (1)");
        SpawnItemAt("Spawn2 (1)");
        SpawnItemAt("Spawn3 (1)");
        SpawnItemAt("Spawn4 (1)");
        SpawnItemAt("Spawn5 (1)");
    }

    private void SpawnItemAt(string name)
    {
        if (Random.Range(0, 100) < 3)
        {
            if (Random.Range(0, 4) == 1)
            {
                Vector3 position = transform.Find(name).position;
                GameObject obj1 = Instantiate(prefabBalloon, position, Quaternion.identity);
                SceneController.balloons.Add(obj1);
            }
            else if (Random.Range(1, 3) == 2)
            {
                Vector3 position = transform.Find(name).position;
                GameObject obj2 = Instantiate(prefabCoffee, position, Quaternion.identity);
                SceneController.coffees.Add(obj2);
            }
            else
            {
                Vector3 position = transform.Find(name).position;
                GameObject obj3 = Instantiate(prefabBike, position, Quaternion.identity);
                SceneController.bikes.Add(obj3);
            }
        }
    }
}