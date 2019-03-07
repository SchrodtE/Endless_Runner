using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{

    public Vector3 jump;
    public Vector3 pos;
    public Vector3 bulletDir;

    private float speed = 20;
    public float jumpForce = 2;
    public float attackRange = 3;
    public float hoverNum = 0;

    public bool hasPower1 = false;
    public bool hasPower2 = false;
    public bool hasPower3 = false;
    public bool hasPower1b = false;
    public bool hasPower2b = false;
    public bool hasPower3b = false;
 
    public static Mesh Player;
    public GameObject projectile;

    //List<GameObject> bullets = new List<GameObject>();

    //public static Mesh Weapon;
    
    SceneController powerLOL;
    SceneController controlRef;
    Rigidbody rb;
    HumanityMeter human;

    //bryan's stuff
    public int maxJumps = 2;
    private bool isGrounded = true;
    private int jumpNum = 0;

    public Vector3 moveDirection;
    public float maxDashTime = 5.0f;
    public float dashSpeed = 50;
    public float dashStoppingSpeed = 0.1f;

    private float currentDashTime;
    
    //private float alpha = 1f;



    // Start is called before the first frame update
    void Start()
    {
        //powerLOL = GameObject.Find("Power").GetComponent<SceneController>();
        rb = GetComponent<Rigidbody>();
        human = GameObject.Find("Slider").GetComponent<HumanityMeter>();

        //bryan's stuff
        currentDashTime = maxDashTime;

        //Instantiate(prefabWeapon2, weaponPos2, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {//start update

        //Debug.DrawRay(transform.position)
        pos = transform.position;
        pos.z += speed * Time.deltaTime;
        //weaponPos1 = transform.position;

        //Vector3 weaponPos2 = transform.position;
        //weaponPos2.z = pos.z;

        if (human.mainSlider.value < 40)
        {
            speed = 20;
        }
        else if (human.mainSlider.value > 60)
        {
            //if (hasPower1b)
        //{
            if (Input.GetButtonDown("Fire2"))
            {
                print("Zoom!");
                currentDashTime = 0.5f;
                speed = 90;
            }
            if (currentDashTime < maxDashTime)
            {
                moveDirection = new Vector3(0, 0, dashSpeed);
                currentDashTime += dashStoppingSpeed;

            }
            else
            {
                speed = 10;
            }
        //}
        }
        else
        {
            speed = 15;
        }

            //power 2
            if (hasPower2)
        {
            
        }
        else
        {
            
        }
        if (pos.y >= 2 && !hasPower3b)
        {
            pos.y = 2;
        }

        //jump logic
        if (pos.y <= .35)
        {
            isGrounded = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (hasPower3 && pos.y <= .35)
            {
                rb.velocity = Vector3.up * 20;
            }
            if (hasPower3b)
            {
                if (isGrounded)
                {
                    rb.velocity = Vector3.up * jumpForce;
                    jumpNum++;
                    isGrounded = false;
                }
                if (jumpNum <= maxJumps)
                {

                    rb.velocity = Vector3.up * jumpForce;
                    jumpNum++;

                }
            }
            if (!hasPower3 && !hasPower3b && pos.y <= .35)
            {
                rb.velocity = Vector3.up * jumpForce;

            }
        }
        //end jump

        //go left
        if (Input.GetButtonDown("Left"))
        {
            if (hasPower1)
            {
                pos.x -= 2;
                rb.velocity = Vector3.zero;
            }

            pos.x -= 1;
            rb.velocity = Vector3.zero;
        }

        //goright
        if (Input.GetButtonDown("Right"))
        {
            if (hasPower1)
            {
                pos.x += 2;
                rb.velocity = Vector3.zero;
            }
            pos.x += 1;
            rb.velocity = Vector3.zero;
        }

        //attack
        if (Input.GetButtonDown("Fire1"))
        {
            if (hasPower2b == true)
            {
                Attack2();
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

        transform.position = pos;

    }//end update
    
    void Attack2()
    {
        GameObject obj = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        bulletDir = Vector3.forward;
        SceneController.projectiles.Add(obj);
    }
}
