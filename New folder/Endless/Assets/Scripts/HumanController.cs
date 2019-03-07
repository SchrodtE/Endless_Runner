using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    private float moveRangeH = 0.8f;
    private Rigidbody rigid;
    public Vector3 moveDirH;
    public float moveForceH = 0f;
    public Vector3 bulletDir;

    public Vector3 pos;

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

        moveDirH = transform.right;

        rigid.velocity = moveDirH * moveForceH;

        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), moveRangeH))
        {
            //ChooseDirection();

            moveDirH = -transform.forward;

            transform.rotation = Quaternion.LookRotation(moveDirH);

            int attPick = Random.Range(0, 4);

            if (human.mainSlider.value > 60)
            {
                if (attPick == 2 || attPick == 1)
                {
                    Attack();
                }
            }
            else if(human.mainSlider.value >= 40 && human.mainSlider.value <= 60)
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

        if (pos.y <= 0.6)
        {
            pos.y = 0.6f;
        }

        transform.position = pos;

    }//end update

    void Attack()
    {
        GameObject obj = Instantiate(EnemyBullet, transform.position, transform.rotation) as GameObject;
        SceneController.bullets.Add(obj);
    }
}
