using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigid;

    public float bulletSpeed = 30f;
    public Vector3 bulletDir;

    static public List<GameObject> enemyBullets = new List<GameObject>();

    ColliderAABB pBox;

    HealthMeter healthMeterRef;

    // Start is called before the first frame update
    void Start()
    {
        pBox = GameObject.Find("Player").GetComponent<ColliderAABB>();

        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletDir = -Vector3.forward;

        rigid.velocity = bulletDir * bulletSpeed;

        //bullets

            foreach (GameObject enemyBullet in enemyBullets)
            {
                if (pBox.CheckOverlap(enemyBullet.GetComponent<ColliderAABB>()))
                {
                    print("enemy bullet Collision!");
                    //ouch
                    healthMeterRef.secondSlider.value--;
                }
            }

        //end bullets
    }
}
