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

    void Start()
    {
        //Fetch the Image from the GameObject
        m_Image = GetComponent<Image>();
    }

    void Update()
    {
        //Press space to change the Sprite of the Image
        if (Input.GetKey(KeyCode.Space))
        {
            m_Image.sprite = m_Sprite;
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_Image.sprite = n_Sprite;
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_Image.sprite = o_Sprite;
        }
    }
}