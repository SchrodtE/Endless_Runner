using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject prefabWeapon;
    public Transform player;
    PlayerRun playerRef;
    
    // Start is called before the first frame update
    void Start()
    {
        //playerRef = GameObject.Find("Player").GetComponent<PlayerRun>();
        //Vector3 position = transform.position;

        //GameObject obj1 = Instantiate(prefabWeapon, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
