using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUI : MonoBehaviour
{
    Image power_Image;
    public Sprite power1;
    public Sprite power1b;
    public Sprite power2;
    public Sprite power2b;
    public Sprite power3;
    public Sprite power3b;
    public Sprite noPower;

    PlayerRun playerRef;
    void Start()
    {
        playerRef = GameObject.Find("Player").GetComponent<PlayerRun>();
        power_Image = GetComponent<Image>();
    }
    void Update()
    {
        if (playerRef.hasPower1)
        {
            power_Image.sprite = power1;
        }
        else if (playerRef.hasPower1b)
        {
            power_Image.sprite = power1b;
        }
        else if (playerRef.hasPower2)
        {
            power_Image.sprite = power2;
        }
        else if (playerRef.hasPower2b)
        {
            power_Image.sprite = power2b;
        }
        else if (playerRef.hasPower3)
        {
            power_Image.sprite = power3;
        }
        else if (playerRef.hasPower3b)
        {
            power_Image.sprite = power3b;
        }
        else
        {
            power_Image.sprite = noPower;
        }

    }
}