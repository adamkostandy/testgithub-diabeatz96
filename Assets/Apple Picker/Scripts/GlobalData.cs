using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    // Start is called before the first frame update

    // Added two global variables to keep track with static methods
    public static int score = 0;
    public static int level = 1;

    public static void resetSharedData() {
        score = 0;
        level = 1;
    }

    public static void incrementScore() {
        score++;
        if(score == 20) {
            incrementLevel();
        }
        
        if(score == 40) {
            incrementLevel();
        }
        
        Debug.Log("Global Score: " + score);
    }

    public static void incrementLevel() {
           level++;
    }

    public static int getScore() {
        return score;
    }

    public static int getLevel() {
        return level;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
