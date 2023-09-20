using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    public int levelOne = 0;
    public int scoreForLevelTwo = 20;
    public int scoreForLevelThree = 50;

    // I will be adding 3 levels to game, each level getting faster apples with some apples being bad
    // When a level is complete 
    public void AppleDestroyed() {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in appleArray) {
            Destroy(apple);
        }

        // Destroy one of the baskets
        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count - 1;
        // Get a reference to that Basket GameObject
        GameObject tBasketGO = basketList[basketIndex];
        // Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        // Restart the game, which doesn't affect HighScore.Score
        if (basketList.Count == 0) {
            

         // Reset the score  and End the Game

            GlobalData.resetSharedData();
            SceneManager.LoadScene("EndGame");
        }
    }

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalData.getLevel() == 2) { 
            Debug.Log("Camera color is now set");
            Camera.main.backgroundColor = Color.red;
        }
        if (GlobalData.getLevel() == 3) {
            // Have the camera change to a different color
            Camera.main.backgroundColor = Color.green;
        }
    }
}
