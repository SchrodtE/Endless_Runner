using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float moveRange;
    public float moveForce = 0f;

    private Rigidbody rigid;
    public Vector3 moveDir;
    public Vector3 bulletDir;

    public Vector3 pos;

    public GameObject projectile;
    HumanityMeter human;

    public GameObject EnemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        human = GameObject.Find("Slider").GetComponent<HumanityMeter>();
    }

    // Update is called once per frame
    void Update()
    {//start update
        pos = transform.position;

        moveDir = transform.right;
        
        rigid.velocity = moveDir * moveForce;

        //picks how long the raycast is
        int range = Random.Range(0, 4);

        if (range == 0)
        {
            moveRange = 0.2f;
        }

        if (range == 1)
        {
            moveRange = 1.0f;
        }

        if (range == 2)
        {
            moveRange = 2.0f;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), moveRange))
        {
            //ChooseDirection();
            
            moveDir = -transform.forward;

            range = Random.Range(0,3);

            transform.rotation = Quaternion.LookRotation(moveDir);

            int attPick = Random.Range(0, 4);

            if (human.mainSlider.value < 40)
            {
                if (attPick == 2 || attPick == 1)
                {
                    Attack();
                }
            }
            else if (human.mainSlider.value >= 40 && human.mainSlider.value <= 60)
            {
                if (attPick == 2 || attPick == 1)
                {
                    Attack();
                }
            }
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

    void Attack()
    {
            GameObject obj = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
    }
}
