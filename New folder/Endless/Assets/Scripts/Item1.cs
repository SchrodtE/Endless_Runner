using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1 : MonoBehaviour
{
    public GameObject prefabItem;
    public GameObject prefabCoffee;
    public GameObject prefabBalloon;
    public GameObject prefabBike;
    public GameObject prefabHumHealth1;
    public GameObject prefabHumHealth2;
    public GameObject prefabHumHealth3;
    public GameObject prefabZomHealth1;
    public GameObject prefabZomHealth2;
    public GameObject prefabZomHealth3;
    public GameObject prefabZombify1;
    public GameObject prefabZombify2;
    public GameObject prefabZombify3;
    public GameObject prefabHumify1;
    public GameObject prefabHumify2;
    public GameObject prefabHumify3;
    public GameObject prefabAcid;
    public GameObject prefabMonLegs;
    public GameObject prefabEar;
    // Start is called before the first frame update
    void Start()
    {
        //ColliderAABB collider = GetComponent<ColliderAABB>();

        //CollisionManager.walls.Add(collider);

        var spawnLocation = Random.Range(0, 5);

        if (spawnLocation == 0) SpawnItemAt("Spawn1 (1)");
        if (spawnLocation == 1) SpawnItemAt("Spawn2 (1)");
        if (spawnLocation == 2) SpawnItemAt("Spawn3 (1)");
        if (spawnLocation == 3) SpawnItemAt("Spawn4 (1)");
        if (spawnLocation == 4) SpawnItemAt("Spawn5 (1)");
    }

    private void SpawnItemAt(string name)
    {
        if (Random.Range(0, 100) < 40) //Likelyhood of any item spawning
        {
            var itemType = Random.Range(0, 100); //random variable that  decides which item spawns
            
            if (itemType < 5) //5% chance of a ballon power up spawning
            {
                Vector3 position = transform.Find(name).position;
                GameObject obj = Instantiate(prefabBalloon, position, Quaternion.identity);
                SceneController.balloons.Add(obj);
                
            }
            if (itemType >= 5 && itemType < 10) //5% chance of a coffee power up spawning
            {
                Vector3 position = transform.Find(name).position;
                GameObject obj = Instantiate(prefabCoffee, position, Quaternion.identity);
                SceneController.coffees.Add(obj);
            }
            if (itemType >= 10 && itemType < 15) //5% chance of a bike power up spawning
            {
                Vector3 position = transform.Find(name).position;
                GameObject obj = Instantiate(prefabBike, position, Quaternion.identity);
                SceneController.bikes.Add(obj);
            }
            if (itemType >= 15 && itemType < 30) //15% chance of a human health pick up spawning
            {
                var humHealType = Random.Range(0, 3);

                Vector3 position = transform.Find(name).position;

                if (humHealType == 0)
                    {
                    GameObject obj1 = Instantiate(prefabHumHealth1, position, Quaternion.identity);
                     SceneController.humheals.Add(obj1);
                    }
                if (humHealType == 1)
                {
                    GameObject obj2 = Instantiate(prefabHumHealth2, position, Quaternion.identity);
                                    SceneController.humheals.Add(obj2);
                }
                if (humHealType == 2)
                {
                    GameObject obj3 = Instantiate(prefabHumHealth3, position, Quaternion.identity);
                                    SceneController.humheals.Add(obj3);
                }

            }
            if (itemType >= 30 && itemType < 45) //15% chance of a zombie health pick up spawning
            {
                var zomHealType = Random.Range(0, 3); // 1/3 chance of each of the different humanifying items spawning

                Vector3 position = transform.Find(name).position;

                if (zomHealType == 0)
                {
                    GameObject obj1 = Instantiate(prefabZomHealth1, position, Quaternion.identity);
                    SceneController.zomheals.Add(obj1);
                }
                if (zomHealType == 1)
                {
                    GameObject obj2 = Instantiate(prefabZomHealth2, position, Quaternion.identity);
                    SceneController.zomheals.Add(obj2);
                }
                if (zomHealType == 2)
                {
                    GameObject obj3 = Instantiate(prefabZomHealth3, position, Quaternion.identity);
                    SceneController.zomheals.Add(obj3);
                }
            }
            if (itemType >= 45 && itemType < 65) //20% chance of a zombifying pick up spawning
            {
                var zombifyType = Random.Range(0, 3); // 1/3 chance of each of the different zombifying items spawning

                Vector3 position = transform.Find(name).position;

                if (zombifyType == 0)
                {
                    GameObject obj1 = Instantiate(prefabZombify1, position, Quaternion.identity);
                    SceneController.zombifies.Add(obj1);
                }
                if (zombifyType == 1)
                {
                    GameObject obj2 = Instantiate(prefabZombify2, position, Quaternion.identity);
                    SceneController.zombifies.Add(obj2);
                }
                if (zombifyType == 2)
                {
                    GameObject obj3 = Instantiate(prefabZombify3, position, Quaternion.identity);
                    SceneController.zombifies.Add(obj3);
                }
            }
            if (itemType >= 65 && itemType < 85) //20% chance of a humanifying pick up spawning
            {
                var humifyType = Random.Range(0, 3);

                Vector3 position = transform.Find(name).position;

                if (humifyType == 0)
                {
                    GameObject obj1 = Instantiate(prefabHumify1, position, Quaternion.identity);
                    SceneController.humifies.Add(obj1);
                }
                if (humifyType == 1)
                {
                    GameObject obj2 = Instantiate(prefabHumify2, position, Quaternion.identity);
                    SceneController.humifies.Add(obj2);
                }
                if (humifyType == 2)
                {
                    GameObject obj3 = Instantiate(prefabHumify3, position, Quaternion.identity);
                    SceneController.humifies.Add(obj3);
                }
            }
            if (itemType >= 85 && itemType < 90) //5% chance of a monster legs power up spawning
            {
                Vector3 position = transform.Find(name).position;
                GameObject obj = Instantiate(prefabMonLegs, position, Quaternion.identity);
                SceneController.monlegs.Add(obj);
            }
            if (itemType >= 90 && itemType < 95) //5% chance of a double jump power up spawning
            {
                Vector3 position = transform.Find(name).position;
                GameObject obj = Instantiate(prefabEar, position, Quaternion.identity);
                SceneController.ears.Add(obj);
            }
            if (itemType >= 95 && itemType < 100) //5% chance of a acid power up spawning
            {
                Vector3 position = transform.Find(name).position;
                GameObject obj = Instantiate(prefabAcid, position, Quaternion.identity);
                SceneController.acids.Add(obj);
            }
        }
    }
}