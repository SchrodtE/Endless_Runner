using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigid;

    public float bulletSpeed = 30f;
    public Vector3 bulletDir;

    static public List<GameObject> enemyBullets = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletDir = -Vector3.forward;

        rigid.velocity = bulletDir * bulletSpeed;
    }
}
