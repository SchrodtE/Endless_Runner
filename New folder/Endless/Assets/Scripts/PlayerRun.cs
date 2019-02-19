using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{

    public float speed = 10;
    public Vector3 jump;
    public float jumpForce = 5;
    public float attackRange = 3f;
    private bool isGrounded = true;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;
        pos.z += speed * Time.deltaTime;
        transform.position = pos;

        if (isGrounded)
        {
            /**if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector3.up * jumpForce;
            }**/

            if (Input.GetButtonDown("Left"))
            {
                if(pos.x >= -1.8)
                {
                    pos.x -= 1;
                    transform.position = pos;
                    rb.velocity = Vector3.zero;
                }
            }

            if (Input.GetButtonDown("Right"))
            {
                if (pos.x <= 1.8)
                {
                    pos.x += 1;
                    transform.position = pos;
                    rb.velocity = Vector3.zero;
                }  
            }

            if (Input.GetButtonDown("Fire1"))
            {
                //Attack();
            }
        }

    }

    /**void Attack()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, attackRange))
        {
            print(hit.transform.name);
        }
    }**/
}
