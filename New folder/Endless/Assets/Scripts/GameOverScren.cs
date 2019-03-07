using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScren : MonoBehaviour
{
    public Image gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneController.isDied == true) gameOver.enabled = true;
        else gameOver.enabled = false;
    }
}
