using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigid;

    public float bulletSpeed = 50f;
    public Vector3 bulletDir;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletDir = Vector3.back;

        rigid.velocity = bulletDir * bulletSpeed;

    }
}
