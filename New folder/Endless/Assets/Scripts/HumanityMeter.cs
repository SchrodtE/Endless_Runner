using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanityMeter : MonoBehaviour
{
    public Slider mainSlider;

    // Start is called before the first frame update
    void Start()
    {
        mainSlider.value = 50;
    }

    // Update is called once per frame
    void Update()
    {
        //print(mainSlider.value);
    }
}
