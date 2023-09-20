using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update

    public ScoreCounter scoreCounter;
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        
    }


    void OnCollisionEnter(Collision coll) {
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple")) {
            Destroy(collidedWith);
            // Increase score
            scoreCounter.score += 1;
            // Track high score
            GlobalData.incrementScore();
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
    }


    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mosePos2D = Input.mousePosition;
        mosePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mosePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
}
