using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float moveRange;
    public float moveForce = 0f;

    private Rigidbody rigid;
    public Vector3 moveDir;
    
    public Vector3 pos;



    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {//start update
        pos = transform.position;

        moveDir = transform.right;
        
        rigid.velocity = moveDir * moveForce;

        //picks how long the raycast is
        int range = Random.Range(0, 3);

        if (range == 0)
        {
            moveRange = 0.8f;
        }

        if (range == 1)
        {
            moveRange = 1.6f;
        }

        if (range == 2)
        {
            moveRange = 2.4f;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), moveRange))
        {
            //ChooseDirection();
            
            moveDir = -transform.forward;

            range = Random.Range(0,3);

            transform.rotation = Quaternion.LookRotation(moveDir);
        }

        //limiter
        if (pos.x >= 2)
        {
            pos.x = 2;
        }
        if (pos.x <= -2)
        {
            pos.x = -2;
        }

        if(pos.y <= 0.6)
        {
            pos.y = 0.6f;
        }
        //end limiter
        transform.position = pos;

    }//end update

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
