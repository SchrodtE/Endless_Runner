using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDebug : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3, Color.green);

    }
}
