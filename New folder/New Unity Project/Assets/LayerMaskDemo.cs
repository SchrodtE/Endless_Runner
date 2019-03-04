using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMaskDemo : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray origin = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(origin, out hit, 100f, 1 << 10 | 1 << 9))
            {
                print("AH");
                hit.collider.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            }
        }
    }
}
