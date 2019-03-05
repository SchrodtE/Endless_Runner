using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitUI : MonoBehaviour
{

    Image m_Image;
    //Set this in the Inspector
    public Sprite m_Sprite;
    public Sprite n_Sprite;
    public Sprite o_Sprite;
    
    HumanityMeter humanityMeterRef;

    void Start()
    {
        humanityMeterRef = GameObject.Find("Slider").GetComponent<HumanityMeter>();
        //Fetch the Image from the GameObject
        m_Image = GetComponent<Image>();
    }

    void Update()
    {
        if (humanityMeterRef.mainSlider.value <= 40)
        {
            m_Image.sprite = m_Sprite;
        }
        else if (humanityMeterRef.mainSlider.value >= 60)
        {
            m_Image.sprite = n_Sprite;
        }
        else
        {
            m_Image.sprite = o_Sprite;
        }

    }
}