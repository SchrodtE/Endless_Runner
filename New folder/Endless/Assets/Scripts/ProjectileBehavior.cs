using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public Transform player;
    public float speed = 200f;

    static public List<GameObject> projectiles = new List<GameObject>();

    ColliderAABB epBox;

    HealthMeter healthMeterRef;

    // Start is called before the first frame update
    void Start()
    {
        epBox = GameObject.Find("Enemy").GetComponent<ColliderAABB>();

        player = GameObject.Find("Player").transform;
        transform.position = player.position;

        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z += speed * Time.deltaTime;

        transform.position = pos;

        foreach (GameObject projectile in projectiles)
        {
            if (epBox.CheckOverlap(projectile.GetComponent<ColliderAABB>()))
            {
                print("OOf!");
                
            }
        }
    }
}
