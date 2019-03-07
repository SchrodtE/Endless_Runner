using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    //public Transform player;
    public float speed = 30f;

    private Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {

        rigid = GetComponent<Rigidbody>();

        //player = GameObject.Find("Player").transform;
        //transform.position = player.position;

        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z += speed * Time.deltaTime;

        transform.position = pos;
    }

}
