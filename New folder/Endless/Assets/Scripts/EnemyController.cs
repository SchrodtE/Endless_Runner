using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public LayerMask whatIsEdge;
    private Rigidbody rigid;
    public Vector3 moveDir;
    public float moveForce = 0f;
    public float distFromEdge = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = ChooseDirection();
        rigid.velocity = moveDir * moveForce;

        if (Physics.Raycast(transform.position, transform.right, distFromEdge, whatIsEdge))
        {
            ChooseDirection();
            transform.rotation = Quaternion.LookRotation(moveDir);
        }
    }

    Vector3 ChooseDirection()
    {
        System.Random ran = new System.Random();
        int i = ran.Next(0, 1);
        Vector3 dir = new Vector3();

        if(i == 0)
        {
            dir = transform.right;
        }else
        {
            dir = -transform.right;
        }

        return dir;
    }
}
