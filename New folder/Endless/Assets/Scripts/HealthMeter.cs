using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMeter : MonoBehaviour
{
    public Slider secondSlider;

    // Start is called before the first frame update
    void Start()
    {
        secondSlider.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //print(secondSlider.value);
    }
}
