using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject prefabChunk;
    public GameObject prefabItem1;
    public GameObject prefabZomHealth;
    public GameObject prefabHealthPickup;
    public Transform player;
    public Transform weapon1;
    public bool hasBeenHit = false;
    public float countdown1 = 0;
    public float countdown2 = 0;
    public float countdown3 = 0;

    List<GameObject> chunks = new List<GameObject>();
    List<GameObject> item1s = new List<GameObject>();
    List<GameObject> heals = new List<GameObject>();
    static public List<GameObject> walls = new List<GameObject>();
    static public List<GameObject> enemies = new List<GameObject>();
    static public List<GameObject> coffees = new List<GameObject>();
    static public List<GameObject> bikes = new List<GameObject>();
    static public List<GameObject> balloons = new List<GameObject>();
    static public List<GameObject> humheals = new List<GameObject>();
    static public List<GameObject> zomheals = new List<GameObject>();
    ColliderAABB pBox;
    PlayerRun playerRef;
    ColliderAABB wBox1;
    PlayerRun weaponRef1;
    HumanityMeter humanityMeterRef;
    //HealthMeter healthMeterRef;
    // Start is called before the first frame update
    void Start()
    {
        pBox = GameObject.Find("Player").GetComponent<ColliderAABB>();
        playerRef = GameObject.Find("Player").GetComponent<PlayerRun>();
        //wBox1 = GameObject.Find("Weapon").GetComponent<ColliderAABB>();
        //weaponRef1 = GameObject.Find("Weapon").GetComponent<PlayerRun>();
        humanityMeterRef = GameObject.Find("Slider").GetComponent<HumanityMeter>();
        //healthMeterRef = GameObject.Find("Slider").GetComponent<HealthMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(healthMeterRef.secondSlider.value);
        //print(countdown);
        if (playerRef.hasPower1 || playerRef.hasPower1b)
        {
            countdown1 = countdown1 + Time.deltaTime;
            if (countdown1 > 10)
            {
                countdown1 = 10;
                playerRef.hasPower1 = false;
                playerRef.hasPower1b = false;

            }
        }
        if (playerRef.hasPower2 || playerRef.hasPower2b)
        {
            countdown2 = countdown2 + Time.deltaTime;
            if (countdown2 > 10)
            {
                countdown2 = 10;
                playerRef.hasPower2 = false;
                playerRef.hasPower2b = false;
            }
        }
        if (playerRef.hasPower3 || playerRef.hasPower3b)
        {
            countdown3 = countdown3 + Time.deltaTime;
            if (countdown3 > 10)
            {
                countdown3 = 10;
                playerRef.hasPower3 = false;
                playerRef.hasPower3b = false;
            }
        }
        if (chunks.Count > 0)
        {
            if (player.position.z - chunks[0].transform.position.z > 14)
            {
                Destroy(chunks[0]);
                chunks.RemoveAt(0);
            }
        } 

        if(enemies.Count > 0)
        {
            if(player.position.z - enemies[0].transform.position.z > 14)
            {
                Destroy(enemies[0]);
                enemies.RemoveAt(0);
            }
        }

        while(chunks.Count < 5)
        {
            // spawn a new chunk
            Vector3 position = Vector3.zero;

            if(chunks.Count > 0)
            {
                position = chunks[chunks.Count - 1].transform.Find("Connector").position;
            }

            GameObject obj = Instantiate(prefabChunk, position, Quaternion.identity);
            chunks.Add(obj);

        }
        if (walls.Count > 0)
        {
            foreach (GameObject wall in walls)
            {
                if (pBox.CheckOverlap(wall.GetComponent<ColliderAABB>()))
                {
                    print("Collission!");
                    if (playerRef.hasPower2)
                    {
                        humanityMeterRef.mainSlider.value += 1;
                    }
                    else
                    {
                        humanityMeterRef.mainSlider.value -= 1;
                    }
                    //healthMeterRef.secondSlider.value -= 1;
                }
            }
        }
        //
        if (item1s.Count > 0)
        {
            if (player.position.z - item1s[0].transform.position.z > 14)
            {
                Destroy(item1s[0]);
                item1s.RemoveAt(0);
            }
        }

        if (heals.Count > 0)
        {
            if(player.position.z - heals[0].transform.position.z > 14)
            {
                Destroy(heals[0]);
                heals.RemoveAt(0);
            }
        }

        while (item1s.Count < 5)
        {
            // spawn a new item1
            Vector3 position = Vector3.zero;

            if (item1s.Count > 0)
            {
                position = item1s[item1s.Count - 1].transform.Find("Connector").position;
            }

            GameObject obj = Instantiate(prefabChunk, position, Quaternion.identity);
            item1s.Add(obj);

        }

        while (heals.Count < 7)
        {
            // spawn a new heals
            Vector3 position = Vector3.zero;

           /** if (heals.Count > 0)
            {
                position = heals[heals.Count - 1].transform.Find("Connector").position;
            }**/

            GameObject obj = Instantiate(prefabChunk, position, Quaternion.identity);
            heals.Add(obj);

        }

        if (coffees.Count > 0)
        {
            foreach (GameObject coffee in coffees)
            {
                if (pBox.CheckOverlap(coffee.GetComponent<ColliderAABB>()))
                {
                    print("Coffee Collision!");
                    countdown1 = 0;
                    if (humanityMeterRef.mainSlider.value <= 40)
                    {
                        print("human");
                        playerRef.hasPower1 = true;
                    }
                    else if (humanityMeterRef.mainSlider.value >= 60)
                    {
                        print("monster");
                        playerRef.hasPower1b = true;
                    }
                }
            }
        }
        //
        if (bikes.Count > 0)
        {
            foreach (GameObject bike in bikes)
            {
                if (pBox.CheckOverlap(bike.GetComponent<ColliderAABB>()))
                {
                    print("Bike Collision!");
                    countdown2 = 0;
                    playerRef.hasPower2 = true;
                }
            }
        }
        //
        if (balloons.Count > 0)
        {
            foreach (GameObject balloon in balloons)
            {
                if (pBox.CheckOverlap(balloon.GetComponent<ColliderAABB>()))
                {
                    print("Balloon Collision!");
                    countdown3 = 0;
                    if (humanityMeterRef.mainSlider.value <= 40)
                    {
                        print("human");
                        playerRef.hasPower3 = true;
                    }
                    else if (humanityMeterRef.mainSlider.value >= 60)
                    {
                        print("monster");
                        playerRef.hasPower3b = true;
                    }
                    //else print("No change!");
                }
            }
        }
    }
}
