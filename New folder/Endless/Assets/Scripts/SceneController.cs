using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject prefabChunk;
    //public GameObject prefabItem1;
   

    public Transform player;
    //public Transform weapon1;

    public bool hasBeenHit = false;

    public float countdown1 = 0;
    public float countdown2 = 0;
    public float countdown3 = 0;

    //audio
    public AudioClip zombieCrunch;
    public AudioClip heal;
    public AudioClip punch;
    public AudioClip coffeeSound;
    public AudioClip bikeSound;
    public AudioClip zombie;

    public AudioClip bgMusic;

    private AudioSource source;
    private float volLow = 0.5f;
    private float volHigh = 1.0f;


    //public Sprite m_Sprite;
    //public Sprite n_Sprite;
    //public Sprite o_Sprite;

    List<GameObject> chunks = new List<GameObject>();


    static public List<GameObject> walls = new List<GameObject>();
    static public List<GameObject> enemies = new List<GameObject>();
    static public List<GameObject> humans = new List<GameObject>();
    static public List<GameObject> coffees = new List<GameObject>();
    static public List<GameObject> bikes = new List<GameObject>();
    static public List<GameObject> balloons = new List<GameObject>();
    static public List<GameObject> humheals = new List<GameObject>();
    static public List<GameObject> zomheals = new List<GameObject>();
    static public List<GameObject> zombifies = new List<GameObject>();
    static public List<GameObject> humifies = new List<GameObject>();
    static public List<GameObject> monlegs = new List<GameObject>();
    static public List<GameObject> ears = new List<GameObject>();
    static public List<GameObject> acids = new List<GameObject>();
    static public List<GameObject> projectiles = new List<GameObject>();
    

    ColliderAABB pBox;
    //ColliderAABB epBox;
    PlayerRun playerRef;
    ColliderAABB wBox1;
    PlayerRun weaponRef1;
    HumanityMeter humanityMeterRef;
    HealthMeter healthMeterRef;
    PortraitUI portraitUIRef;

    //HealthMeter healthMeterRef;
    // Start is called before the first frame update
    void Start()
    {
        pBox = GameObject.Find("Player").GetComponent<ColliderAABB>();
        playerRef = GameObject.Find("Player").GetComponent<PlayerRun>();
        //epBox = GameObject.Find("Enemy").GetComponent<ColliderAABB>();
        //wBox1 = GameObject.Find("Weapon").GetComponent<ColliderAABB>();
        //weaponRef1 = GameObject.Find("Weapon").GetComponent<PlayerRun>();
        humanityMeterRef = GameObject.Find("Slider").GetComponent<HumanityMeter>();
        healthMeterRef = GameObject.Find("OtherSlider").GetComponent<HealthMeter>();

        source = GetComponent<AudioSource>();
        source.PlayOneShot(bgMusic, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {//update start

        //Press space to change the Sprite of the Image
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
        //Power2
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
        //Power3
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
        //chunk
        if (chunks.Count > 0)
        {
            if (player.position.z - chunks[0].transform.position.z > 14)
            {
                Destroy(chunks[0]);
                chunks.RemoveAt(0);
            }
        }

        //enemies
        if (enemies.Count > 0)
        {
            foreach (GameObject enemy in enemies)
            {
                if (pBox.CheckOverlap(enemy.GetComponent<ColliderAABB>()))
                {
                    //print("ZomCOLLISION!!");
                    
                    //if human colliding with monsters
                    if (humanityMeterRef.mainSlider.value <= 40)
                    {
                        //if has weapon
                        if (playerRef.hasPower2)
                        {
                            //make more human
                            humanityMeterRef.mainSlider.value--;
                        }
                        else
                        {
                            //if no weapon, ouch
                            healthMeterRef.secondSlider.value--;
                            //play sound
                            float vol = Random.Range(volLow, volHigh);
                            source.PlayOneShot(zombieCrunch, vol);
                        }
                        Destroy(enemies[0]);
                        enemies.RemoveAt(0);
                    }
                    //do damage if inbetween
                    if (humanityMeterRef.mainSlider.value > 40 && humanityMeterRef.mainSlider.value < 60)
                    {
                        healthMeterRef.secondSlider.value--;
                    }
                }
            }
            if (player.position.z - enemies[0].transform.position.z > 14)
            {
                Destroy(enemies[0]);
                enemies.RemoveAt(0);
            }
        }
        //end of enemies
        //humans
        if (humans.Count > 0)
        {
            foreach (GameObject human in humans)
            {
                if (pBox.CheckOverlap(human.GetComponent<ColliderAABB>()))
                {
                    //print("HumanCOLLISION!!");
                   
                    //if monster colliding with humans
                    if (humanityMeterRef.mainSlider.value >= 60)
                    {
                        //ouch
                        healthMeterRef.secondSlider.value--;
                        //play sound
                        float vol = Random.Range(volLow, volHigh);
                        source.PlayOneShot(punch, vol);
                    }
                    //if human colliding with human with weapon
                    else if (humanityMeterRef.mainSlider.value <= 40 && playerRef.hasPower2)
                    {
                        //make more monster
                        humanityMeterRef.mainSlider.value++;
                        //play sound
                        float vol = Random.Range(volLow, volHigh);
                        source.PlayOneShot(zombie, vol);
                    }
                    //do damage if inbetween
                    else
                    {
                        healthMeterRef.secondSlider.value--;
                    }
                }
            }
            if (player.position.z - humans[0].transform.position.z > 14)
            {
                Destroy(humans[0]);
                humans.RemoveAt(0);
            }
        }
        //end of humans

        //chunks
        while (chunks.Count < 5)
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
        //end of chunks

        //walls
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
        //end of walls

        if (humheals.Count > 0)
        {
            foreach (GameObject humheal in humheals)
            {
                if (pBox.CheckOverlap(humheal.GetComponent<ColliderAABB>()))
                {
                    
                    //heals both human and inbetween
                    if (humanityMeterRef.mainSlider.value < 60)
                    {
                        healthMeterRef.secondSlider.value++;
                        //play sound
                        source.PlayOneShot(heal, 0.3f);
                    }
                    //hurts monster
                    else if (humanityMeterRef.mainSlider.value >=60)
                    {
                        healthMeterRef.secondSlider.value--;
                    }
                    Destroy(humheal);
                    humheals.Remove(humheal);

                }
            }
            if (player.position.z - humheals[0].transform.position.z > 14)
            {
                Destroy(humheals[0]);
                humheals.RemoveAt(0);
            }
        }

        if (zomheals.Count > 0)
        {
            foreach (GameObject zomheal in zomheals)
            {
                if (pBox.CheckOverlap(zomheal.GetComponent<ColliderAABB>()))
                {
                    
                    //heals both monster and inbetween
                    if (humanityMeterRef.mainSlider.value <= 40)
                    {
                        healthMeterRef.secondSlider.value--;
                        //play sound
                        float vol = Random.Range(volLow, volHigh);
                        source.PlayOneShot(zombie, vol);
                    }
                    //hurts human
                    else if (humanityMeterRef.mainSlider.value >= 60)
                    {
                        healthMeterRef.secondSlider.value++;
                    }
                    Destroy(zomheal);
                    zomheals.Remove(zomheal);
                }
            }
            if (player.position.z - zomheals[0].transform.position.z > 14)
            {
                Destroy(zomheals[0]);
                zomheals.RemoveAt(0);
            }
        }

        if (humifies.Count > 0)
        {
            foreach (GameObject humify in humifies)
            {
                if (pBox.CheckOverlap(humify.GetComponent<ColliderAABB>()))
                {
                    
                    humanityMeterRef.mainSlider.value -= 1;
                    Destroy(humify);
                    humifies.Remove(humify);
                }
                
            }
            if (player.position.z - humifies[0].transform.position.z > 14)
            {
                Destroy(humifies[0]);
                humifies.RemoveAt(0);
            }
        }

        if (zombifies.Count > 0)
        {
            foreach (GameObject zombify in zombifies)
            {
                if (pBox.CheckOverlap(zombify.GetComponent<ColliderAABB>()))
                {
                    
                    humanityMeterRef.mainSlider.value += 1;
                    //play sound
                    float vol = Random.Range(volLow, volHigh);
                    source.PlayOneShot(zombie, vol);

                    Destroy(zombify);
                    zombifies.Remove(zombify);
                }
            }
            if (player.position.z - zombifies[0].transform.position.z > 14)
            {
                Destroy(zombifies[0]);
                zombifies.RemoveAt(0);
            }
        }

        if (acids.Count > 0)
        {
            foreach (GameObject acid in acids)
            {
                if (pBox.CheckOverlap(acid.GetComponent<ColliderAABB>()))
                { 
                    
                    if (humanityMeterRef.mainSlider.value >= 60)
                    {
                        print("monster");
                        playerRef.hasPower2b = true;
                        Destroy(acid);
                        acids.Remove(acid);
                    }
                }
            }
            if (player.position.z - acids[0].transform.position.z > 14)
            {
                Destroy(acids[0]);
                acids.RemoveAt(0);
            }
        }

        if (monlegs.Count > 0)
        {
            foreach (GameObject monleg in monlegs)
            {
                if (pBox.CheckOverlap(monleg.GetComponent<ColliderAABB>()))
                { 
                    
                    if (humanityMeterRef.mainSlider.value >= 60)
                    {
                        print("monster");
                        playerRef.hasPower1b = true;
                        Destroy(monleg);
                        monlegs.Remove(monleg);
                    }
                }
            }
            if (player.position.z - monlegs[0].transform.position.z > 14)
            {
                Destroy(monlegs[0]);
                monlegs.RemoveAt(0);
            }
        }

        if (ears.Count > 0)
        {
            foreach (GameObject ear in ears)
            {
                if (pBox.CheckOverlap(ear.GetComponent<ColliderAABB>()))
                { 
                    
                    if (humanityMeterRef.mainSlider.value >= 60)
                    {
                        print("monster");
                        playerRef.hasPower3b = true;
                        Destroy(ear);
                        ears.Remove(ear);
                    }
                }
                
            }
            if (player.position.z - ears[0].transform.position.z > 14)
            {
                Destroy(ears[0]);
                ears.RemoveAt(0);
            }

        }
        //coffee
        if (coffees.Count > 0)
        {
            foreach (GameObject coffee in coffees)
            {
                if (pBox.CheckOverlap(coffee.GetComponent<ColliderAABB>()))
                {
                    
                    countdown1 = 0;
                    if (humanityMeterRef.mainSlider.value <= 40)
                    {
                        print("human");
                        playerRef.hasPower1 = true;
                        //play sound
                        source.PlayOneShot(coffeeSound, 0.6f);
                        Destroy(coffee);
                        coffees.Remove(coffee);
                    }

                }
            }
            if (coffees.Count > 0)
            {

                if (player.position.z - coffees[0].transform.position.z > 14)
                {
                    Destroy(coffees[0]);
                    coffees.RemoveAt(0);
                }
            }
        }
        //end coffee

        //bike
        if (bikes.Count > 0)
        {
            foreach (GameObject bike in bikes)
            {
                if (pBox.CheckOverlap(bike.GetComponent<ColliderAABB>()))
                {
                    print("Bike Collision!");
                    countdown2 = 0;
                    if (humanityMeterRef.mainSlider.value <= 40)
                    {
                        print("human");
                        playerRef.hasPower2 = true;
                        //play sound
                        source.PlayOneShot(bikeSound, 1f);
                        Destroy(bike);
                        bikes.Remove(bike);
                    }
                }
            }
            if (bikes.Count > 0)
            {

                if (player.position.z - bikes[0].transform.position.z > 14)
                {
                    Destroy(bikes[0]);
                    bikes.RemoveAt(0);
                }
            }
        }
        //bike

        

        //balloon
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
                        Destroy(balloon);
                        balloons.Remove(balloon);
                    }
                    //else print("No change!");
                }
            }
            if (balloons.Count > 0)
            {

                if (player.position.z - balloons[0].transform.position.z > 14)
                {
                    Destroy(balloons[0]);
                    balloons.RemoveAt(0);
                }
            }
        }//end balloon

    }//end of update

}//end of class
