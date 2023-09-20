using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class LevelText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text uiText;

    void Start()
    {
        uiText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalData.getLevel() == 1) {
            uiText.text = "Level: 1";
        }
        else if(GlobalData.getLevel() == 2) {
            uiText.text = "Level: 2";
        }
        else if(GlobalData.getLevel() == 3) {
            uiText.text = "Level: 3";
        }
        else {
            uiText.text = "THE END GAME BABY";
        }

    }
}
