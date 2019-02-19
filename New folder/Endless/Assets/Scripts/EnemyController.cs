using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveRange = 2f;
    private Rigidbody rigid;
    public Vector3 moveDir;
    public float moveForce = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = transform.right;

        rigid.velocity = moveDir * moveForce;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, moveRange))
        {
            //ChooseDirection();
            moveDir = -transform.forward;
            transform.rotation = Quaternion.LookRotation(moveDir);
        }
    }

        /**Vector3 ChooseDirection()
        {
            System.Random ran = new System.Random();
            int i = ran.Next(0, 1);
            Vector3 dir = new Vector3();

            if(i == 0)
            {
                dir = transform.right;
            }

            if(i == 1)
            {
                dir = -transform.right;
            }

            return dir;
        }**/
}
