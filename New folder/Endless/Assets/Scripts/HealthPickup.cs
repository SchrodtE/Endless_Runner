using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public GameObject prefabHumHealth;
    public GameObject prefabZomHealth;

    // Start is called before the first frame update
    void Start()
    {
        var ran = Random.Range(0,5);

        if (ran == 0)  SpawnHealthAt("Spawn1 (1)"); 
        if (ran == 1)  SpawnHealthAt("Spawn2 (1)");
        if (ran == 2)  SpawnHealthAt("Spawn3 (1)");
        if (ran == 3)  SpawnHealthAt("Spawn4 (1)");
        if (ran == 4)  SpawnHealthAt("Spawn5 (1)");
    }

    // Update is called once per frame
    private void SpawnHealthAt(string name)
    {
        if (Random.Range(0, 20) < 2)
        {
            if (Random.Range(0, 2) == 1)
            {
                Vector3 position = transform.Find(name).position;
                GameObject pickup1 = Instantiate(prefabHumHealth, position, Quaternion.identity);
                SceneController.humheals.Add(pickup1);
            }
            else
            {
                Vector3 position = transform.Find(name).position;
                GameObject pickup2 = Instantiate(prefabZomHealth, position, Quaternion.identity);
                SceneController.zomheals.Add(pickup2);
            }
        }
    }
}
