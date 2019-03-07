using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanityMeter : MonoBehaviour
{
    float maxHealth = 100;
    float currentHealth;
    public Slider mainSlider;

    // Start is called before the first frame update
    void Start()
    {
        mainSlider.value = 20;
    }

    // Update is called once per frame
    void Update() {
        if ((int)mainSlider.value < 40)
        {
            mainSlider.image.color = Color.Lerp(Color.green, Color.green, currentHealth / maxHealth);
        }
        else if ((int)mainSlider.value > 60)
        {
            mainSlider.image.color = Color.Lerp(Color.red, Color.green, currentHealth / maxHealth);
        }
        else
        {
            mainSlider.image.color = Color.Lerp(Color.yellow, Color.green, currentHealth / maxHealth);
        }
        
        //flash colors
       // else {
       //     mainSlider.image.color = Color.Lerp(Color.green, Color.white, Mathf.PingPong(Time.time, 1f));
        
       // }
    }
}
