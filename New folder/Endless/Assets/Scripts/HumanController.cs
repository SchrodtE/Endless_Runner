using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    private float moveRangeH = 0.8f;
    private Rigidbody rigid;
    public Vector3 moveDirH;
    public float moveForceH = 0f;

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

        moveDirH = transform.right;

        rigid.velocity = moveDirH * moveForceH;

        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), moveRangeH))
        {
            //ChooseDirection();

            moveDirH = -transform.forward;

            transform.rotation = Quaternion.LookRotation(moveDirH);
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

        if (pos.y <= 0.6)
        {
            pos.y = 0.6f;
        }

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
